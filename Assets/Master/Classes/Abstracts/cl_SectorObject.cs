using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
abstract public class cl_SectorObject
{
    //Variable Names
    public const string HULLPOINTS = "HullPoints";
    public const string HULLPOINTS_MAX = "HullPoints_Max";
    public const string SHIELD = "Shield";
    public const string SHIELD_MAX = "Shield_Max";

    //Tags
    public const string STATION = "Station";
    public const string SHIP = "Ship";
    public const string ASTEROID = "Asteroid";

    public const string TRADER = "Trader";
    public const string PIRATE = "Pirate";
    public const string PLAYER = "Player";

    //Variables
    public List<string> tags;
    public Vector3 position;

    protected int hp, hpMax;
    protected int shield, shieldMax;
    protected float evasion;
    protected List<cl_Weapon> weapons;
    protected List<cl_ShipSystem> systems;

    public cl_SectorObject()
    {
        tags = new List<string>();
        position = Random.insideUnitSphere * 100;
        hp = hpMax = 0;
        shield = shieldMax = 0;
    }

    public cl_SectorObject(List<string> Tags, Vector3 Position)
    {

    }

    abstract public void Update(cl_Sector Sector);

    abstract public T GetVar<T>(string Name);

    abstract public void SetVar<T>(string Name, T Val);

    abstract public void CallMethod(string Name, params object[] args);

    //Default methods
    virtual public void Damaged(cl_Weapon Weapon)
    {
        int damageTaken = Weapon.GetVar<int>(cl_Weapon.DAMAGE);
        if (Weapon.tags.Contains(cl_Weapon.PIERCING) == false)
        {
            if (Weapon.tags.Contains(cl_Weapon.EXPLOSIVE))
            {
                damageTaken *= 2;
                shield -= damageTaken;
                damageTaken = -(shield / 2);
            }
            else
            {
                shield -= damageTaken;
                damageTaken = -shield;
            }
        }
        if (damageTaken > 0)
        {
            if (Weapon.tags.Contains(cl_Weapon.KINETIC))
            {
                hp -= damageTaken * 2;
            }
            else
            {
                hp -= damageTaken;
            }
            
            if (Weapon.tags.Contains(cl_Weapon.ENERGY) == false)
            {
                damageTaken /= 2;
            }
            for(int i = 0; i < damageTaken; i++)
            {
                int target = Random.Range(0, 4 + systems.Count);
                if(target - 4 >= 0)
                {
                    systems[target].Damaged(Weapon);
                }
            }
        }
    }

    //Base Methods
    
    virtual protected void AttackShip(cl_SectorObject Target, int Weapon)
    {
        if (Weapon < weapons.Count && Weapon >= 0)
        {
            if (weapons[Weapon].GetVar<float>(cl_Weapon.COOLDOWNTIMER) >= weapons[Weapon].GetVar<float>(cl_Weapon.COOLDOWN))
            {
                if (Random.value < weapons[Weapon].GetVar<float>(cl_Weapon.ACCURACY) * (1.0f - evasion))
                {
                    Target.Damaged(weapons[Weapon]);
                }
            }
        }
        else
        {
            throw new System.Exception("Index " + Weapon + " is not a valid weapon");
        }
    }
}
