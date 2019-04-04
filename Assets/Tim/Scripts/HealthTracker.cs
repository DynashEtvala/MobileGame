using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour
{
    int healthVal;
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
        healthVal = player.GetComponent<PlayerCommands>().healthRemaining;
        text.text = "Health: " + healthVal;
        if(healthVal <= 100)
        {
            text.color = Color.green;
        }
        if (healthVal <= 75)
        {
            text.color = new Color(1.0f, 0.39f, 0.0f, 1);

        }
        if (healthVal <= 50)
        {
            text.color = new Color(0.59f, 0.0f, 0, 1);

        }
        if (healthVal <= 25)
        {
            text.color = new Color(0.59f, 0.0f, 0, 1);

        }
    }
}