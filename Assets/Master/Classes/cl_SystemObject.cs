using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
abstract public class cl_SystemObject
{
    public const string HULLPOINTS = "HullPoints";
    public const string HULLPOINTS_MAX = "HullPoints_Max";
    public const string SHIELD = "Shield";
    public const string SHIELD_MAX = "Shield_Max";

    protected List<string> tags;

    protected Vector3 position;
    protected int hp, hpMax;
    protected int shield, shieldMax;

    public cl_SystemObject()
    {
        tags = new List<string>();
        position = Vector3.zero;
    }

    public cl_SystemObject(List<string> Tags, Vector3 Position)
    {

    }

    abstract public void Update();

    abstract public int? GetInt(string Name);

    abstract public string GetString(string Name);

    abstract public float? GetFloat(string Name);

    abstract public bool? GetBool(string Name);

    abstract public T GetVar<T>(string Name);

    abstract public void SetVar<T>(string Name, T Val);

    protected T GetVarTest<T>(T Val)
    {
        return Val;
    }
}
