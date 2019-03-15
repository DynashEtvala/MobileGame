using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour {

    PlayerShipController instance;

    Weapon[] weapons;

    [Header("Health Aspects")]
    [SerializeField]
    int hullHealth;
    [SerializeField]
    int shieldHealth;
    [SerializeField]
    int shieldRoomHealth;
    [SerializeField]
    int bridgeRoomHealth;
    [SerializeField]
    int weaponsRoomHealth;
    [SerializeField]
    int cargoRoomHealth;

    [Space(1)]
    [Header("Phone Functions")]
    [SerializeField]
    float nuclearIntensity;
    [SerializeField]
    float power;
    [SerializeField]
    bool canConnectToSystems;

    public struct ShipReturnData
    {
        int x;
        int y;
        float f1;
        float f2;
        bool b;
        Weapon[] weapons;

        public ShipReturnData(int x, int y, float f1, float f2, bool b, Weapon[] w)
        {
            this.x = x;
            this.y = y;
            this.f1 = f1;
            this.f2 = f2;
            this.b = b;
            this.weapons = w;
        }
    }

    public struct Weapon
    {
        public string name;
        public bool isKinematic;
        public int baseDamage;
        public int health;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void Update() {
        nuclearIntensity = scr_SystemVariableController.Volume_Percent;
        power = scr_SystemVariableController.Screen_Brightness;
        canConnectToSystems = scr_SystemVariableController.Wifi_Enabled;
    }

    public void DamageShip(bool isKinetic, int damage)
    {
        if (!isKinetic)
        {
            if (shieldHealth > 0)
            {
                shieldHealth -= damage;
                Debug.Log("Shields took " + damage + " damage");
                if (shieldHealth < 0)
                {
                    shieldHealth = 0;
                }
            }
        }
        else
        {
            hullHealth -= damage;
            Debug.Log("Hull took " + damage + " damage");
        }
        if (hullHealth <= 0)
        {
            Debug.Log("Ship destroyed");
        }
    }

    public ShipReturnData GetShipStatus()
    {
        return new ShipReturnData(hullHealth, shieldHealth, nuclearIntensity, power, canConnectToSystems, weapons);
    }

    public bool FireWeapon(Weapon weapon)
    {
        if (weapon.health < 0)
            return false;
        Debug.Log("Weapon: " + weapon.name + " Fired");
        return true;
    }

    public void FireWeapons()
    {
        foreach(Weapon w in weapons)
        {
            FireWeapon(w);
        }
    }
}
