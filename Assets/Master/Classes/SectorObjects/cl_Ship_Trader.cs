using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class cl_Ship_Trader : cl_SectorObject
{
    //Method Names
    public const string OPENSHOP = "OpenShop";
    public const string ATTACKSHIP = "AttackShip";

    //Variables
    Vector3 direction;
    float speed;
    public int currencyVal;
    public int weaponVal;
    public GyroControl gyro;
    public bool buttonPressed;
    List<cl_Weapon> Inventory;
    string invText = "";
    public cl_Ship_Trader() : base()
    {
        tags.Add(SHIP);
        tags.Add(TRADER);
        direction = Random.onUnitSphere;
        speed = Random.Range(0.75f, 1.25f);
        gyro = GameObject.Find("Gyro").GetComponent<GyroControl>();
        for (int i = 0; i < Random.Range(2, 4); i++)
        {
            switch (Random.Range(0, 5))
            {
                case 0:
                    Inventory.Add(new cl_W_Default());
                    weaponVal = Random.Range(5, 10);
                    invText += "Default Weapon " + weaponVal + "\n";
                    break;
                case 1:
                    Inventory.Add(new cl_W_HighDmg());
                    weaponVal = Random.Range(10, 30);
                    invText += "HighDmg Weapon " + weaponVal + "\n";
                    break;
                case 2:
                    Inventory.Add(new cl_W_LowDmg());
                    weaponVal = Random.Range(2, 5);
                    invText += "LowDmg Weapon " + weaponVal + "\n";
                    break;
                case 3:
                    Inventory.Add(new cl_W_Explosive());
                    weaponVal = Random.Range(40, 50);
                    invText += "Explosive Weapon " + weaponVal + "\n";
                    break;
                case 4:
                    Inventory.Add(new cl_W_Energy());
                    weaponVal = Random.Range(60, 80);
                    invText += "Energy Weapon " + weaponVal + "\n";
                    break;

            }
        }
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
            case TRADE:
                Trade((GameObject)args[0]);
                break;
            default:
                throw new System.Exception("Method name " + Name + " is not valid");
        }
    }

    //Class Methods
    public void OpenShop()
    {
            if (buttonPressed == true)
            {
                for (int t = 0; t < Inventory.Count; t++)
                {
                    gyro.dispScrnPrefab.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Shop\n Hello Welcom to the shop\n" + invText;
                }

            }
            else
            {
                Debug.Log("Not the Player");
            }
    }
    public void Trade(GameObject button)
    {
        button.GetComponent<Button>().onClick.AddListener(OnClick);
    }


    public void AttackShip(cl_SectorObject Target, int Weapon)
    {

    }
    protected override void OnDestroy(cl_SectorObject Attacker)
    {
        base.OnDestroy(Attacker);
        if (Attacker.tags.Contains(PLAYER))
        {
            Attacker.GetVar<PlayerController>(cl_Ship_Player.CONTROLLER).currency += currencyVal;
        }
    }
    public void OnClick()
    {
        if (tags.Contains(PLAYER))
        {
            buttonPressed = true;
            OpenShop();
        }
        else
        {
            buttonPressed = false;

        }
    }
}
