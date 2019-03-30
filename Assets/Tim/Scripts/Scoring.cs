using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{

    GameObject player;
    public List<GameObject> playerCmps;
    public int playerDmgCmps;
    int score;
    public Text scoreText;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCmps = player.GetComponent<PlayerCommands>().Components;
        score = 5;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < playerCmps.Count; i++)
        {
            if (playerCmps[i].transform.gameObject.GetComponent<Renderer>().material.color != Color.green && score > 0)
            {
                if(player.GetComponent<PlayerCommands>().DamagedComps >= 3) 
                {
                    score--;
                    scoreText.text = "Score: " + score;
                    return;
                }
                else
                {
                    score++;
                    scoreText.text = "Score: " + score;
                    return;
                }
            }
            if (score > 9999 || score < 0 || playerDmgCmps == 4)
            {
                return;
            }
        }
    }
}
