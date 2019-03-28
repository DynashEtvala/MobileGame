using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SectorController : MonoBehaviour {
    public cl_Sector currSector;
    public int sectorNum;

	// Use this for initialization
	void Start () {
        sectorNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private cl_Sector GenerateSector()
    {
        List<cl_SectorObject> tempObjectList = new List<cl_SectorObject>();

        int objectGenCount = 5; //TODO: make variable based on certain factors
        for(int i = 0; i < objectGenCount; i++)
        {

        }

        return new cl_Sector(sectorNum, tempObjectList);
    }
}
