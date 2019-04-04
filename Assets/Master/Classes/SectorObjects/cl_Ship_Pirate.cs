using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class cl_Ship_Pirate : cl_SectorObject
{
    //Variable Names
    public const string DIRECTION = "Direction";
    public const string SPEED = "Speed";

    //Method Names
    public const string ATTACKSHIP = "AttackShip";

    //Variables
    Vector3 direction;
    float speed;
    float targetTimer;
    cl_SectorObject target;
    public int currencyVal;
    public cl_Ship_Pirate()
    {
        tags.Add(SHIP);
        tags.Add(PIRATE);
        direction = Random.onUnitSphere;
        speed = Random.Range(0.75f, 1.25f);
    }

    public cl_Ship_Pirate(Vector3 Position) : this()
    {
        position = Position;
    }

    public cl_Ship_Pirate(Vector3 Position, int SectorNum) : this(Position)
    {
        throw new System.NotImplementedException();
    }

    override public void Update(cl_Sector Sector)
    {
        base.Update(Sector);
        position += direction * speed * Time.deltaTime;
        if(target == null)
        {
            if(targetTimer < 10)
            {
                targetTimer += Time.deltaTime;
            }
            else
            {
                if (Random.Range(0, 10) == 0)
                {
                    List<int> targetWeights = new List<int>();
                    for(int i = 0; i < Sector.sectorObjects.Count; i++)
                    {
                        if(Sector.sectorObjects[i].tags.Contains(PLAYER) || Sector.sectorObjects[i].tags.Contains(TRADER))
                        {
                            targetWeights.Add(i);
                        }
                    }
                    target = Sector.sectorObjects[targetWeights[Random.Range(0, targetWeights.Count)]];
                }
                targetTimer -= 10;
            }
        }
        else
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                AttackShip(target, i);
            }
        }
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
    protected override void OnDestroy(cl_SectorObject Attacker)
    {
        base.OnDestroy(Attacker);
        if (Attacker.tags.Contains(PLAYER))
        {
            Attacker.GetVar<PlayerController>(cl_Ship_Player.CONTROLLER).currency += currencyVal;
        }
    }
}
