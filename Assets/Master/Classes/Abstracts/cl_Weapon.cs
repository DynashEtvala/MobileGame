using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
abstract public class cl_Weapon
{

    protected int damage;
    protected float curCooldown;
    protected float cooldown;
    protected float accuracy;

    public List<string> tags;

    //Constructors
    public cl_Weapon()
    {
        damage = 1;
        curCooldown = cooldown = 2;
        accuracy = 0.9f;
    }

    // Update is called once per frame
    virtual public void Update()
    {
        if (curCooldown < cooldown)
        {
            curCooldown += Time.deltaTime;
        }
    }

    abstract public T GetVar<T>(string Name);

    abstract public void SetVar<T>(string Name, T Val);

    abstract public void CallMethod(string Name, params object[] args);
}