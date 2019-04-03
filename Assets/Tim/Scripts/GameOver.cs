using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    GameObject player;
    GameObject UI;
    int scoreValue;
    public Text text;
    public Camera camera;
    public List<GameObject> uiElements;
    void Start()
    {
       player = GameObject.Find("Player");
        UI = GameObject.Find("UI");
        text.gameObject.SetActive(false);
        text.fontSize = 75;
        text.rectTransform.sizeDelta = new Vector2(687.6f, 177);
        text.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerCommands>().Lose(player.GetComponent<PlayerCommands>().healthRemaining) == false)
        {
            text.gameObject.SetActive(false);
            uiElements[3].SetActive(false);
            uiElements[4].SetActive(false);
            uiElements[5].SetActive(false);
        }
        if (player.GetComponent<PlayerCommands>().Lose(player.GetComponent<PlayerCommands>().healthRemaining) == true) 
        {
            player.SetActive(false);
            uiElements[0].SetActive(false);
            uiElements[1].SetActive(false);
            uiElements[2].SetActive(false);
            uiElements[3].SetActive(true);
            uiElements[4].SetActive(true);
            uiElements[5].SetActive(true);
            text.gameObject.SetActive(true);
            scoreValue = player.GetComponent<PlayerCommands>().score.scoreVal;
            text.text = "Youy Have Fallen to the Void\n Your Final Score is: " + scoreValue;
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = Color.black;
        }
    }
}
