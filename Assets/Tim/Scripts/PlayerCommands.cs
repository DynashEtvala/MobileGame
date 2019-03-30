using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommands : MonoBehaviour
{
    int minval = 1;
    public int maxVal;
    public int hit;
    public Camera cam;
    public List<string> tagValue;
    public List<GameObject> Components;
    public int DamagedComps;
    GameObject enemy;
    public int StartingHealth;
    public int healthRemaining; 
    void Start()
    {
        for (int t = 0; t < Components.Count; t++)
        {
            Components[t].transform.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        healthRemaining = StartingHealth;
    }
    void Update()
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
                    if (rayHit.transform.gameObject.tag == tagValue[i] && tagValue[i] == "Fire" && healthRemaining > 0)
                    {
                        int randHitVal = Random.Range(minval, maxVal);
                        if (hit == randHitVal)
                        {
                            Debug.Log("Hit");
                            healthRemaining = healthRemaining - 10;
                            int randomComp = Random.Range(0, Components.Count);
                            Debug.Log(randomComp);
                            Handheld.Vibrate();
                            if (healthRemaining < StartingHealth && healthRemaining != 0)
                            {
                                if (Components[randomComp].transform.gameObject.GetComponent<Renderer>().material.color == Color.green)
                                {
                                    Components[randomComp].transform.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.39f, 0.0f, 1);
                                    Debug.Log("100% Health");
                                    break;
                                }
                                if (Components[randomComp].transform.gameObject.GetComponent<Renderer>().material.color == new Color(1.0f, 0.39f, 0, 1))
                                {
                                    Components[randomComp].transform.gameObject.GetComponent<Renderer>().material.color = new Color(0.59f, 0.0f, 0, 1);
                                    Debug.Log("50% Health");
                                    break;
                                }
                                if (Components[randomComp].transform.gameObject.GetComponent<Renderer>().material.color == new Color(0.59f, 0.0f, 0, 1))
                                {
                                    Components[randomComp].transform.gameObject.GetComponent<Renderer>().material.color = Color.black;
                                    Debug.Log("25% Health");
                                    break;
                                }
                                if (Components[randomComp].transform.gameObject.GetComponent<Renderer>().material.color == Color.black)
                                {


                                    Debug.Log("0% Health");
                                    break;
                                }
                            }

                            else if(healthRemaining <= 0)
                            {
                                Debug.Log("You Lose");
                                Components[0].transform.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
                                break;
                            }

                        }
                        else
                        {
                            Debug.Log("Miss");
                        }
                    }
                    if (rayHit.transform.gameObject.tag == tagValue[i] && tagValue[i] == "Repair" && healthRemaining > 0)
                    {
                        DamagedComps = Random.Range(0, Components.Count);
                        if (Components[DamagedComps].transform.gameObject.GetComponent<Renderer>().material.color == Color.black)
                        {
                            Components[DamagedComps].transform.gameObject.GetComponent<Renderer>().material.color = new Color(0.59f, 0.0f, 0, 1);
                            Debug.Log("25% Health");
                            break;
                        }
                        if (Components[DamagedComps].transform.gameObject.GetComponent<Renderer>().material.color == new Color(0.59f, 0.0f, 0, 1))
                        {
                            Components[DamagedComps].transform.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.39f, 0.0f, 1);
                            Debug.Log("50% Health");
                            break;
                        }
                        if (Components[DamagedComps].transform.gameObject.GetComponent<Renderer>().material.color == new Color(1.0f, 0.39f, 0.0f, 1))
                        {
                            Components[DamagedComps].transform.gameObject.GetComponent<Renderer>().material.color = Color.green;
                            Debug.Log("100% Health");
                            break;
                        }
                    }
                }
            }
        }
    }
}
