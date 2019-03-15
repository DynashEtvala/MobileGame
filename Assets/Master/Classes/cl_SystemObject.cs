using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
abstract public class cl_SystemObject {
    protected List<string> tags;

    Vector3 position;
    int hp, hpMax;
    int shield, shieldMax;

    public cl_SystemObject()
    {
        tags = new List<string>();
        position = Vector3.zero;
    }

    public cl_SystemObject(List<string> Tags, Vector3 Position)
    {

    }

    abstract public void Update();

    abstract public T GetVar<T>(string Name);

    abstract public void SetVar<T>(string Name, T Val);
}
