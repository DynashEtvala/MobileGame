using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class cl_Ship_Trader : cl_SectorObject
{
    //Method Names
    public const string OPENSHOP = "OpenShop";
    public const string ATTACKSHIP = "AttackShip";

    //Variables
    Vector3 direction;
    float speed;

    public cl_Ship_Trader() : base()
    {
        tags.Add(SHIP);
        tags.Add(TRADER);
        direction = Random.onUnitSphere;
        speed = Random.Range(0.75f, 1.25f);
    }

    override public void Update(cl_Sector Sector)
    {
        position += direction * speed * Time.deltaTime;
        base.Update(Sector);
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
            case OPENSHOP:
                OpenShop();
                break;
            case ATTACKSHIP:
                if (args[0] is cl_SectorObject && args[1] is int)
                {
                    AttackShip((cl_SectorObject)args[0], (int)args[1]);
                }
                break;
            default:
                throw new System.Exception("Method name " + Name + " is not valid");
        }
    }

    //Class Methods
    public void OpenShop()
    {

    }

    public void AttackShip(cl_SectorObject Target, int Weapon)
    {

    }
}
