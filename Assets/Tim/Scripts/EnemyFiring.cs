using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFiring : MonoBehaviour
{

    public List<Component> playerComponents;
    [HideInInspector]
    public int timer;
    public float Reload;
    int bulletsFired;
    public int Capacity;
    GameObject player;
    PlayerCommands playerCom;
    public int playerHealthRemain;
    int playerStartingHealth;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCom = player.GetComponent<PlayerCommands>();
        playerHealthRemain = player.GetComponent<PlayerCommands>().healthRemaining;
        playerStartingHealth = player.GetComponent<PlayerCommands>().StartingHealth;
        playerComponents = player.GetComponent<PlayerCommands>().Components;
        playerHealthRemain = playerStartingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCom.Lose(playerHealthRemain) == false)
        {
            int randNumber = Random.Range(0, playerComponents.Count);
            timer = timer + 1;
            if (timer < Reload)
            {
                Debug.Log("Not Firing");
            }
            if (timer > Reload)
            {
                if (playerComponents[randNumber].DmgTaken == 0)
                {
                    playerComponents[randNumber].Obj.transform.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.39f, 0.0f, 1);
                    playerComponents[randNumber].DmgTaken = 1;
                    playerHealthRemain = playerHealthRemain - 2;
                    player.GetComponent<PlayerCommands>().healthRemaining = playerHealthRemain;
                    playerCom.score.scoreVal = playerCom.score.scoreVal - 10;
                    timer = 0;
                    return;
                }
                if(playerComponents[randNumber].DmgTaken == 1)
                {
                    playerComponents[randNumber].Obj.transform.gameObject.GetComponent<Renderer>().material.color = new Color(0.59f, 0.0f, 0, 1);
                    playerComponents[randNumber].DmgTaken = 2;
                    playerHealthRemain = playerHealthRemain - 4;
                    player.GetComponent<PlayerCommands>().healthRemaining = playerHealthRemain;
                    playerCom.score.scoreVal = playerCom.score.scoreVal - 20;
                    timer = 0;
                    return;
                }
                if (playerComponents[randNumber].DmgTaken == 2)
                {
                    playerComponents[randNumber].Obj.transform.gameObject.GetComponent<Renderer>().material.color = Color.black;
                    playerComponents[randNumber].DmgTaken = 3;
                    playerHealthRemain = playerHealthRemain - 6;
                    player.GetComponent<PlayerCommands>().healthRemaining = playerHealthRemain;
                    playerCom.score.scoreVal = playerCom.score.scoreVal - 30;
                    timer = 0;
                    return;
                }
                if (playerComponents[randNumber].DmgTaken == 3)
                {
                    playerComponents[randNumber].Obj.transform.gameObject.GetComponent<Renderer>().material.color = Color.gray;
                    playerComponents[randNumber].DmgTaken = 4;
                    playerCom.grayedComponents = playerCom.grayedComponents + 1;
                    randNumber = Random.Range(0, playerComponents.Count - playerCom.grayedComponents);
                    playerCom.score.scoreVal = playerCom.score.scoreVal - 40;
                    timer = 0;
                    if (bulletsFired >= 0 && bulletsFired <= Capacity)
                    {
                        int DmgDealt = Random.Range(0,50);
                        Debug.Log("Firing 8 Shots");
                        playerHealthRemain = playerHealthRemain - DmgDealt;
                        player.GetComponent<PlayerCommands>().healthRemaining = playerHealthRemain;
                        bulletsFired = bulletsFired + 1;
                    }
                    if (bulletsFired == 4 && timer > Reload)
                    {
                        bulletsFired = 0;
                        return;
                    }
                }
                if (playerComponents[randNumber].DmgTaken == 4)
                {
                    Debug.Log("Component is Stuned");
                    playerComponents[randNumber].Obj.transform.gameObject.GetComponent<Renderer>().material.color = Color.blue;
                    timer = 0;
                    return;

                }
            }
        }
    }
}
