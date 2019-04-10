using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class cl_Ship_Player : cl_SectorObject
{

    //Phone Functions
    [Header("Phone Functions")]
    [SerializeField]
    float nuclearIntensity;
    [SerializeField]
    float power;
    [SerializeField]
    bool canConnectToSystems;

    PlayerController playerController;

    //Method Names
    public const string ATTACKSHIP = "AttackShip";
    public const string CONTROLLER = "Controller";

    public cl_Ship_Player() : base()
    {

        tags.Add(SHIP);
        tags.Add(PLAYER);

        weapons.Add(new cl_W_LowDmg());
        weapons.Add(new cl_W_LowDmg());
        weapons.Add(new cl_W_LowDmg());
        weapons.Add(new cl_W_LowDmg());

        nuclearIntensity = scr_SystemVariableController.Volume;
        power = scr_SystemVariableController.Screen_Brightness;
        canConnectToSystems = scr_SystemVariableController.Wifi_Enabled;
    }

    public cl_Ship_Player(PlayerController playerController) : this()
    {
        this.playerController = playerController;
    }

    override public void Update(cl_Sector Sector)
    {
        base.Update(Sector);
        nuclearIntensity = scr_SystemVariableController.Volume;
        power = scr_SystemVariableController.Screen_Brightness;
        canConnectToSystems = scr_SystemVariableController.Wifi_Enabled;
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
            case CONTROLLER:
                return (T)(object)playerController;
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
}
