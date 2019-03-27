using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class cl_System {
    List<cl_SystemObject> systemObjects;
    int systemNum;

    public cl_System()
    {
        systemObjects = new List<cl_SystemObject>();
        systemNum = -1;
    }

    public cl_System(int SystemNum, List<cl_SystemObject> SystemObjects)
    {
        systemNum = SystemNum;
        systemObjects = SystemObjects;
    }
}
