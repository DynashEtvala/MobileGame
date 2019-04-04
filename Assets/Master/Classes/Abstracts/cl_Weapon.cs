using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
abstract public class cl_Weapon
{
    //Variable Names
    public const string DAMAGE = "Damage";
    public const string COOLDOWN = "CoolDown";
    public const string COOLDOWNTIMER = "CoolDownTimer";
    public const string ACCURACY = "Accuracy";

    //Tags
    public const string KINETIC = "Kinetic";
    public const string ENERGY = "Energy";
    public const string EXPLOSIVE = "Explosive";

    public const string PIERCING = "Piercing";

    //Variables
    protected int damage;
    protected float cooldownTimer;
    protected float cooldown;
    protected float accuracy;

    public List<string> tags;

    //Constructors
    public cl_Weapon()
    {
        damage = 1;
        cooldownTimer = cooldown = 2;
        accuracy = 0.9f;
    }

    // Update is called once per frame
    virtual public void Update()
    {
        if (cooldownTimer < cooldown)
        {
            cooldownTimer += Time.deltaTime;
        }
    }

    abstract public T GetVar<T>(string Name);

    abstract public void SetVar<T>(string Name, T Val);

    abstract public void CallMethod(string Name, params object[] args);
}