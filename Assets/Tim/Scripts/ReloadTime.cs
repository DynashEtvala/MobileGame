using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReloadTime : MonoBehaviour
{
    public int time;
    public Text text;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        time = player.GetComponent<EnemyFiring>().timer;
        text.fontSize = 55;
        text.color = Color.white;
        text.resizeTextForBestFit = true;
    }

    // Update is called once per frame
    void Update()
    {
        time = player.GetComponent<EnemyFiring>().timer;
        text.text = "Reload: " + time;
    }
}

