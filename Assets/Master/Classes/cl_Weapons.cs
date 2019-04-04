using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
abstract public class cl_Weapons {

    public Weapons[] weapons;
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

    }
    public cl_Weapons()
    {
        int damage = 0;
        float curCooldown = 0.0f;
        float Cooldown = 0.0f;
    }
public void Attack(cl_SectorObject sectorObject, int weaponFired)
    {
        weapons[weaponFired].Accuracy = Random.Range(0, 1);
        if (weapons[weaponFired].curCooldown < weapons[weaponFired].Cooldown)
          {
                int hp = sectorObject.GetVar<int>("HullPoints");
                hp = hp - weapons[weaponFired].damage;
          }
        if(weapons[weaponFired].curCooldown > weapons[weaponFired].Cooldown)
        {
            weapons[weaponFired].curCooldown = weapons[weaponFired].curCooldown - Time.deltaTime;
        }
    }
}
public class Weapons
{
    public int damage;
    public float Accuracy;
    public float Cooldown;
    public float curCooldown;
}
