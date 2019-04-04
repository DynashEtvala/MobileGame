using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class cl_W_Default : cl_Weapon
{

    public cl_W_Default() : base()
    {

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
