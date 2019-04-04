using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreTracker : MonoBehaviour
{
    public int scoreVal;
    public Text text;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        text.fontSize = 55;
        text.color = Color.white;
        text.resizeTextForBestFit = true;
    }

    // Update is called once per frame
    void Update()
    {
        scoreVal = player.GetComponent<PlayerCommands>().score.scoreVal;
        text.text = "Score: " + scoreVal;
    }
}
