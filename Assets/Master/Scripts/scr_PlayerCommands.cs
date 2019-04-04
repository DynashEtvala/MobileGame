using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PlayerCommands : MonoBehaviour
{
    int minval = 1;
    public int grayedComponents = 0;
    public int maxVal;
    public int hit;
    public Camera cam;
    public List<Component> Components = new List<Component>();
    public List<string> tagValue;
    public Score score;
    public int StartingHealth;
    public int healthRemaining;
    void Start()
    {
        for (int t = 0; t < Components.Count; t++)
        {
            Components[t].Obj.transform.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        healthRemaining = StartingHealth;
    }
    void Update()
    {
        if (Lose(healthRemaining) == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 touchPosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.farClipPlane);
                Vector3 touchPosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane);
                Vector3 touchPosF = cam.ScreenToWorldPoint(touchPosFar);
                Vector3 touchPosN = cam.ScreenToWorldPoint(touchPosNear);
                RaycastHit rayHit;

                if (Physics.Raycast(touchPosN, touchPosF - touchPosN, out rayHit))
                {
                    for (int i = 0; i < tagValue.Capacity; i++)
                    {
                        if (rayHit.transform.gameObject.tag == tagValue[i] && tagValue[i] != "Fire" && healthRemaining > 0)
                        {
                            switch (tagValue[i])
                            {
                                case "Sensor":
                                    Debug.Log("Sensors Online");
                                    rayHit.transform.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Random.ColorHSV());
                                    break;
                                case "Targeting":
                                    Debug.Log("Targeting Onlne");
                                    rayHit.transform.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Random.ColorHSV());
                                    break;
                                case "Health":
                                    Debug.Log("Your Health Is:" + healthRemaining);
                                    rayHit.transform.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Random.ColorHSV());
                                    break;
                            }
                        }
                        if (rayHit.transform.gameObject.tag == tagValue[i] && tagValue[i] == "Fire")
                        {
                            int randHitVal = Random.Range(minval, maxVal);
                            if (hit == randHitVal)
                            {
                                Debug.Log("Hit");
                                healthRemaining = healthRemaining - 10;
                                Handheld.Vibrate();
                                int randomComp = Random.Range(0, Components.Count);
                                Debug.Log(randomComp);
                                if (healthRemaining < StartingHealth && healthRemaining != 0)
                                {
                                    if (Components[randomComp].DmgTaken == 0)
                                    {
                                        Components[randomComp].Obj.transform.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.39f, 0.0f, 1);
                                        Components[randomComp].DmgTaken = 1;
                                        score.scoreVal = score.scoreVal - 10;
                                        Debug.Log("100% Health");
                                        break;
                                    }
                                    if (Components[randomComp].DmgTaken == 1)
                                    {
                                        Components[randomComp].Obj.transform.gameObject.GetComponent<Renderer>().material.color = new Color(0.59f, 0.0f, 0, 1);
                                        Components[randomComp].DmgTaken = 2;
                                        score.scoreVal = score.scoreVal - 20;
                                        Debug.Log("50% Health");
                                        break;
                                    }
                                    if (Components[randomComp].DmgTaken == 2)
                                    {
                                        Components[randomComp].Obj.transform.gameObject.GetComponent<Renderer>().material.color = Color.black;
                                        Components[randomComp].DmgTaken = 3;
                                        score.scoreVal = score.scoreVal - 30;
                                        Debug.Log("25% Health");
                                        break;
                                    }
                                    if (Components[randomComp].DmgTaken == 3)
                                    {
                                        Components[randomComp].Obj.transform.gameObject.GetComponent<Renderer>().material.color = Color.gray;
                                        Components[randomComp].DmgTaken = 4;
                                        grayedComponents = grayedComponents + 1;
                                        randomComp = Random.Range(0, Components.Count - grayedComponents);
                                        score.scoreVal = score.scoreVal - 40;
                                        Debug.Log("0% Health");
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Debug.Log("Miss");
                            }
                        }
                        if (rayHit.transform.gameObject.tag == tagValue[i] && tagValue[i] == "Repair")
                        {
                            int DamagedComp = Random.Range(0, Components.Count);
                            if (Components[DamagedComp].DmgTaken == 1)
                            {
                                Components[DamagedComp].Obj.transform.gameObject.GetComponent<Renderer>().material.color = Color.green;
                                Components[DamagedComp].DmgTaken = 0;
                                score.scoreVal = score.scoreVal + 30;
                                Handheld.Vibrate();
                                Debug.Log("100% Health");
                                break;
                            }
                            if (Components[DamagedComp].DmgTaken == 2)
                            {
                                Components[DamagedComp].Obj.transform.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.39f, 0.0f, 1);
                                Components[DamagedComp].DmgTaken = 1;
                                score.scoreVal = score.scoreVal + 20;
                                Debug.Log("50% Health");
                                break;
                            }
                            if (Components[DamagedComp].DmgTaken == 3)
                            {
                                Components[DamagedComp].Obj.transform.gameObject.GetComponent<Renderer>().material.color = new Color(0.59f, 0.0f, 0, 1);
                                Components[DamagedComp].DmgTaken = 2;
                                score.scoreVal = score.scoreVal + 10;

                                Debug.Log("25% Health");
                                break;
                            }
                            if (Components[DamagedComp].DmgTaken == 4)
                            {
                                Components[DamagedComp].Obj.transform.gameObject.GetComponent<Renderer>().material.color = Color.black;
                                Components[DamagedComp].DmgTaken = 3;
                                score.scoreVal = score.scoreVal + 0;
                                Debug.Log("10% Health");
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
public bool Lose(int health)
{
        if (health <= 0)
        {
            Debug.Log("You Lose");
            return true;
        }
        else
        {
            return false;
        }
    }
}