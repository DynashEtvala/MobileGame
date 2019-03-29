using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SectorController : MonoBehaviour {
    public cl_Sector currSector;
    public int sectorNum;
    public GameObject sectorObjectPrefab;
    public List<GameObject> sectorObjects;

	// Use this for initialization
	void Start () {
        sectorNum = 0;
        currSector = GenerateSector();
        sectorObjects = new List<GameObject>();
        for(int i = 0; i < 5; i++)
        {
            sectorObjects.Add(Instantiate(sectorObjectPrefab));
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		for(int i = 0; i < sectorObjects.Count; i++)
        {
            sectorObjects[i].transform.position = currSector.sectorObjects[i].position;
        }
	}

    private cl_Sector GenerateSector()
    {
        List<cl_SectorObject> tempObjectList = new List<cl_SectorObject>();

        int objectGenCount = 5; //TODO: make variable based on certain factors
        while(tempObjectList.Count < objectGenCount)
        {
            List<string> typeWeights = new List<string>();
            if (!ListContainsObjectWithTag(tempObjectList, cl_SectorObject.STATION))
            {
                for(int j = 0; j < 3; j++)
                {
                    typeWeights.Add(cl_SectorObject.STATION);
                }
            }
            for(int j = 0; j < (objectGenCount / 2) - ListObjectWithTagCount(tempObjectList, cl_SectorObject.SHIP); j++)
            {
                typeWeights.Add(cl_SectorObject.SHIP);
            }
            for(int j = 0; j < 2; j++)
            {
                typeWeights.Add(cl_SectorObject.ASTEROID);
            }

            if (typeWeights.Count > 0)
            {
                switch (typeWeights[Random.Range(0, typeWeights.Count)])
                {
                    case cl_SectorObject.STATION:
                        {
                            List<string> factionWeights = new List<string>();
                            for (int j = 0; j < 6 - ListObjectWithTagCount(tempObjectList, cl_SectorObject.TRADER); j++)
                            {
                                factionWeights.Add(cl_SectorObject.TRADER);
                            }
                            for (int j = 0; j < sectorNum / 3; j++)
                            {
                                factionWeights.Add(cl_SectorObject.PIRATE);
                            }
                            if (factionWeights.Count > 0)
                            {
                                switch (factionWeights[Random.Range(0, factionWeights.Count)])
                                {
                                    case cl_SectorObject.PIRATE:
                                        tempObjectList.Add(new cl_Station_Pirate());
                                        break;
                                    case cl_SectorObject.TRADER:
                                        tempObjectList.Add(new cl_Station_Trader());
                                        break;
                                }
                            }
                        }
                        break;
                    case cl_SectorObject.SHIP:
                        {
                            List<string> factionWeights = new List<string>();
                            for (int j = 0; j < 1 - ListObjectWithTagCount(tempObjectList, cl_SectorObject.TRADER); j++)
                            {
                                factionWeights.Add(cl_SectorObject.TRADER);
                            }
                            for (int j = 0; j < sectorNum + 10; j++)
                            {
                                factionWeights.Add(cl_SectorObject.PIRATE);
                            }
                            if (factionWeights.Count > 0)
                            {
                                switch (factionWeights[Random.Range(0, factionWeights.Count)])
                                {
                                    case cl_SectorObject.PIRATE:
                                        tempObjectList.Add(new cl_Ship_Pirate());
                                        break;
                                    case cl_SectorObject.TRADER:
                                        tempObjectList.Add(new cl_Ship_Trader());
                                        break;
                                }
                            }
                        }
                        break;
                    case cl_SectorObject.ASTEROID:
                        {
                            tempObjectList.Add(new cl_Asteroid());
                        }
                        break;
                }
            }
        }

        return new cl_Sector(sectorNum, tempObjectList);
    }

    private bool ListContainsObjectWithTag(List<cl_SectorObject> list, string tag)
    {
        for(int i = 0; i < list.Count; i++)
        {
            if (list[i].tags.Contains(tag))
            {
                return true;
            }
        }
        return false;
    }

    private int ListObjectWithTagCount(List<cl_SectorObject> list, string tag)
    {
        int result = 0;
        for(int i = 0; i < list.Count; i++)
        {
            if (list[i].tags.Contains(tag))
            {
                result++;
            }
        }
        return result;
    }
}
