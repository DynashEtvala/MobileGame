using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiring : MonoBehaviour {

    public List<GameObject> playerComponents;
    public int playerDamagedComps;
    int fireAt;
    float timer;
    public float Charge;
    GameObject player;
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerComponents = player.GetComponent<PlayerCommands>().Components;
    }

    // Update is called once per frame
    void Update ()
    {
        timer = timer + Time.deltaTime;
        player.GetComponent<PlayerCommands>().DamagedComps = playerDamagedComps;
        if (timer < Charge)
        {
            Debug.Log("Not Firing");
        }
        if(timer > Charge)
        {
            if (playerComponents[fireAt].transform.gameObject.GetComponent<Renderer>().material.color != Color.green && playerDamagedComps < 4)
            {
                   if (timer < 2 || timer > 1)
                   {
                        player.GetComponent<PlayerCommands>().healthRemaining = player.GetComponent<PlayerCommands>().healthRemaining - 1;
                        timer = 0.0f;
                        return;

                   }
            }
            //Color is equal to black but with the DamagedComponents is equal to 4
            if (playerComponents[fireAt].transform.gameObject.GetComponent<Renderer>().material.color != Color.green && playerDamagedComps == 4)
            {
                    if (timer < 2 || timer > 1)
                    {
                    player.GetComponent<PlayerCommands>().healthRemaining = player.GetComponent<PlayerCommands>().healthRemaining - 4;
                    timer = 0.0f;
                    return;

                    }
            }
            if (playerComponents[fireAt].transform.gameObject.GetComponent<Renderer>().material.color == Color.green && playerDamagedComps <= 0)
            {
                    playerComponents[fireAt].transform.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.39f, 0.0f, 1);
                    playerDamagedComps = playerDamagedComps + 1;
                    player.GetComponent<PlayerCommands>().DamagedComps = playerDamagedComps;
                    timer = 0.0f;
                    return;
            }
            if (playerComponents[fireAt].transform.gameObject.GetComponent<Renderer>().material.color == Color.green && playerDamagedComps >= 0)
            {
                playerComponents[fireAt].transform.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.39f, 0.0f, 1);
                playerDamagedComps = playerDamagedComps - 1;
                player.GetComponent<PlayerCommands>().DamagedComps = playerDamagedComps;
                timer = 0.0f;
                return;
            }
            if (playerComponents[fireAt].transform.gameObject.GetComponent<Renderer>().material.color == new Color(1.0f, 0.39f, 0.0f, 1))
            {
                    playerComponents[fireAt].transform.gameObject.GetComponent<Renderer>().material.color = new Color(0.59f, 0.0f, 0, 1);
                    timer = 0.0f;
                    return;
            }
            if (playerComponents[fireAt].transform.gameObject.GetComponent<Renderer>().material.color == new Color(0.59f, 0.0f, 0, 1))
            {
                    playerComponents[fireAt].transform.gameObject.GetComponent<Renderer>().material.color = Color.black;
                    timer = 0.0f;
                    return;
            }
        }
        if(player.GetComponent<PlayerCommands>().healthRemaining <= 0)
        {
            timer = Charge;
            player.gameObject.SetActive(false);
        }
    }
}
