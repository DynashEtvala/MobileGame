using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class cl_W_HighDmg : cl_Weapon
{
    cl_Weapon weapon;
    public cl_W_HighDmg() : base()
    {
        tags.Add(KINETIC);
        tags.Add(PIERCING);
        name = "High Damage Weapon";
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    //Generic Call Methods
    public override T GetVar<T>(string Name)
    {
        switch (Name)
        {
            case DAMAGE:
                return (T)(object)damage;
            case COOLDOWN:
                return (T)(object)cooldown;
            case COOLDOWNTIMER:
                return (T)(object)cooldownTimer;
            case ACCURACY:
                return (T)(object)accuracy;
            default:
                throw new System.Exception("Variable name " + Name + " is not valid");
        }
    }

    override public void SetVar<T>(string Name, T Val)
    {
        switch (Name)
        {
            case DAMAGE:
                if(Val.GetType() == damage.GetType())
                {
                    damage = (int)(object)Val;
                }
                break;
            case ACCURACY:
                if(Val.GetType() == accuracy.GetType())
                {
                    accuracy = (int)(object)Val;
                }
                break;
            case COOLDOWN:
                if (Val.GetType() == cooldown.GetType())
                {
                    cooldown = (int)(object)Val;
                }
                break;
            case COOLDOWNTIMER:
                if (Val.GetType() == cooldownTimer.GetType())
                {
                    cooldownTimer = (int)(object)Val;
                }
                break;
            default:
                throw new System.Exception("Variable name " + Name + " is not valid");
        }
    }

    public override void CallMethod(string Name, params object[] args)
    {
        switch (Name)
        {
            default:
                throw new System.Exception("Method name " + Name + " is not valid");
        }
    }
}

