using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class cl_ShipSystem
{
    public int hp, hpMax;
    float repairTimer, repairTime;

    // Update is called once per frame
    void Update()
    {
        if (hp < hpMax)
        {
            if (repairTimer < repairTime)
            {
                repairTimer += Time.deltaTime;
            }
            else
            {
                hp++;
                repairTimer = 0;
            }
        }
    }

    //Default Methods
    virtual public void Damaged(cl_Weapon Weapon)
    {
        if (hp > 0)
        {
            hp--;
        }
    }
}
