using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class cl_Station_Trader : cl_SystemObject {


    override public void Update()
    {

    }

    override public int? GetInt(string Name)
    {
        switch (Name)
        {
            case HULLPOINTS:
                return hp;
            case HULLPOINTS_MAX:
                return hpMax;
            case SHIELD:
                return shield;
            case SHIELD_MAX:
                return shieldMax;
        }
        return null;
    }

    override public string GetString(string Name)
    {
        return null;
    }

    override public float? GetFloat(string Name)
    {
        return null;
    }

    override public bool? GetBool(string Name)
    {
        return null;
    }

    public override T GetVar<T>(string Name)
    {
        switch (Name)
        {
            case HULLPOINTS:
                return hp;
            case HULLPOINTS_MAX:
                return hpMax;
            case SHIELD:
                return shield;
            case SHIELD_MAX:
                return shieldMax;
        }
    }

    override public void SetVar<T>(string Name, T Val)
    {
        switch (Name)
        {
            case HULLPOINTS:
                if (Val.GetType() == hp.GetType())
                {
                    hp = (int)(object)Val;
                    T temp = (T)(object)hp;
                }
                break;
            case HULLPOINTS_MAX:
                break;
            case SHIELD:
                break;
            case SHIELD_MAX:
                break;
        }
    }
}
