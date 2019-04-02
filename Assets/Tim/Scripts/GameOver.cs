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
        text.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerCommands>().Lose(player.GetComponent<PlayerCommands>().healthRemaining) == false)
        {
            text.gameObject.SetActive(false);
            uiElements[3].SetActive(false);
            uiElements[4].SetActive(false);
        }
            if (player.GetComponent<PlayerCommands>().Lose(player.GetComponent<PlayerCommands>().healthRemaining) == true)
        {
            text.gameObject.SetActive(true);
            uiElements[0].SetActive(false);
            uiElements[1].SetActive(false);
            uiElements[2].SetActive(false);
            uiElements[3].SetActive(true);
            uiElements[4].SetActive(false);
            Destroy(player);
            player.GetComponent<PlayerCommands>().score.scoreVal = scoreValue;
            text.text = "Your Score Is: " + scoreValue;
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = Color.black;
        }
    }
}
