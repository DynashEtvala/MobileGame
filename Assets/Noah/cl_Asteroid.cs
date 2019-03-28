using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class cl_Asteroid : cl_SectorObject
{
    //Method Names
    public const string MINERESOURCES = "MineResources";

    public cl_Asteroid()
    {
        tags.Add(ASTEROID);
    }

    override public void Update()
    {

    }

    //Generic Call Methods
    public override T GetVar<T>(string Name)
    {
        switch (Name)
        {
            case HULLPOINTS:
                return (T)(object)hp;
            case HULLPOINTS_MAX:
                return (T)(object)hpMax;
            case SHIELD:
                return (T)(object)shield;
            case SHIELD_MAX:
                return (T)(object)shieldMax;
        }
        throw new System.ArgumentException("Variable name " + Name + " is not valid");
    }

    override public void SetVar<T>(string Name, T Val)
    {
        switch (Name)
        {
            case HULLPOINTS:
                if (Val.GetType() == hp.GetType())
                {
                    hp = (int)(object)Val;
                }
                break;
            case HULLPOINTS_MAX:
                break;
            case SHIELD:
                break;
            case SHIELD_MAX:
                break;
            default:
                throw new System.Exception("Variable name " + Name + " is not valid");
        }
    }

    public override void CallMethod(string Name, params object[] args)
    {
        switch (Name)
        {
            case MINERESOURCES:
                if (args[0] is int)
                {
                    MineResources((int)args[0]);
                }
                break;
            default:
                throw new System.Exception("Method name " + Name + " is not valid");
        }
    }

    //Class Methods
    public string MineResources(int Weapon) //Needs to return something not sure what yet.
    {
        return null;
    }
}
