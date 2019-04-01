using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiring : MonoBehaviour {

    public List<GameObject> playerComponents;
    int minval = 1;
    public int maxVal;
    public int hit;
    float timer;
    public float Charge;
    GameObject player;
    public float playerHealthRemain;
    int playerHealth;
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerCommands>().StartingHealth;
        playerHealthRemain = player.GetComponent<PlayerCommands>().healthRemaining;
        playerHealthRemain = playerHealth;
    }

    // Update is called once per frame
    void Update ()
    {
        timer = timer + Time.deltaTime;
		if(timer < Charge)
        {
            Debug.Log("Not Firing");
        }
        if(timer > Charge)
        {
            for (int i = 0; i < playerComponents.Count; i++)
            {
                if (playerComponents[i].transform.gameObject.GetComponent<Renderer>().material.color != Color.green)
                {
                    playerHealthRemain = playerHealthRemain - Time.deltaTime;
                }
                if (playerComponents[i].transform.gameObject.GetComponent<Renderer>().material.color == Color.green)
                {
                    playerComponents[i].transform.gameObject.GetComponent<Renderer>().material.color = Color.red;
                    timer = 0.0f;
                    break;
                }
            }
        }
     }
}
