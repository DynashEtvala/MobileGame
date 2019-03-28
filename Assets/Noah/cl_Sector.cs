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
}
