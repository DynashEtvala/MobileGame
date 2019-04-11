using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class cl_Sector {
    public List<cl_SectorObject> sectorObjects;
    int sectorNum;

    public cl_Sector()
    {
        sectorObjects = new List<cl_SectorObject>();
        sectorNum = -1;
    }

    public cl_Sector(int SectorNum, List<cl_SectorObject> SectorObjects)
    {
        sectorNum = SectorNum;
        sectorObjects = SectorObjects;
    }

    public void Update()
    {
        for(int i = 0; i < sectorObjects.Count; i++)
        {
            sectorObjects[i].Update(this);
            if (sectorObjects[i].GetVar<int>("HullPoints") <= 0 && sectorObjects[i].tags.Contains("Ship"))
            {
                sectorObjects.Remove(sectorObjects[i]);
                GameObject.Destroy(GameObject.FindGameObjectWithTag("Gyro").GetComponent<GyroControl>().blips[i]);
                GameObject.FindGameObjectWithTag("Gyro").GetComponent<GyroControl>().blips.Remove(GameObject.FindGameObjectWithTag("Gyro").GetComponent<GyroControl>().blips[i]);
                GameObject.Destroy(GameObject.FindGameObjectWithTag("Gyro").GetComponent<GyroControl>().dispScrn);
                GameObject.Destroy(GameObject.FindGameObjectWithTag("Gyro").GetComponent<GyroControl>().fireButton);
                i--;
            }
        }
    }
}
