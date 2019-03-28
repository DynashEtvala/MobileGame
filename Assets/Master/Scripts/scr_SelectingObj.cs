using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SelectingObj : MonoBehaviour
{
    int minval = 1;
    public int maxVal;
    public int hit;
    public Camera cam;
    public List<string> tagValue;
    public List<GameObject> Compnents;
    public int StartingHealth;
    int healthRemaining;
    void Start()
    {
        for (int t = 0; t < Compnents.Count; t++)
        {
            Compnents[t].transform.gameObject.GetComponent<Renderer>().material.color = Color.green;
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
                    if (rayHit.transform.gameObject.tag == tagValue[i] && tagValue[i] != "Fire")
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
                            healthRemaining = healthRemaining - 4;
                            int randomComp = Random.Range(0, Compnents.Count);
                            Debug.Log(randomComp);
                            Handheld.Vibrate();
                            if (healthRemaining < StartingHealth)
                            {
                                if (Compnents[randomComp].transform.gameObject.GetComponent<Renderer>().material.color == Color.green)
                                {
                                    Compnents[randomComp].transform.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.39f, 0.0f, 1);
                                    Debug.Log("100% Health");
                                    break;
                                }
                                if (Compnents[randomComp].transform.gameObject.GetComponent<Renderer>().material.color == new Color(1.0f, 0.39f, 0, 1))
                                {
                                    Compnents[randomComp].transform.gameObject.GetComponent<Renderer>().material.color = new Color(0.59f, 0.0f, 0, 1);
                                    Debug.Log("50% Health");
                                    break;
                                }
                                if (Compnents[randomComp].transform.gameObject.GetComponent<Renderer>().material.color == new Color(0.59f, 0.0f, 0, 1))
                                {
                                    Compnents[randomComp].transform.gameObject.GetComponent<Renderer>().material.color = Color.black;
                                    Debug.Log("25% Health");
                                    break;
                                }
                                if (Compnents[randomComp].transform.gameObject.GetComponent<Renderer>().material.color == Color.black)
                                {
                                    Debug.Log("0% Health");
                                    break;
                                }
                            }

                            else
                            {
                                break;
                            }

                        }
                        else
                        {
                            Debug.Log("Miss");
                        }
                    }
                    if (rayHit.transform.gameObject.tag == tagValue[i] && tagValue[i] == "Repair")
                    {
                        int DamagedComp = Random.Range(0, Compnents.Count);
                        if (Compnents[DamagedComp].transform.gameObject.GetComponent<Renderer>().material.color == Color.black)
                        {
                            Compnents[DamagedComp].transform.gameObject.GetComponent<Renderer>().material.color = new Color(0.59f, 0.0f, 0, 1);
                            Debug.Log("25% Health");
                            break;
                        }
                        if (Compnents[DamagedComp].transform.gameObject.GetComponent<Renderer>().material.color == new Color(0.59f, 0.0f, 0, 1))
                        {
                            Compnents[DamagedComp].transform.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.39f, 0.0f, 1);
                            Debug.Log("50% Health");
                            break;
                        }
                        if (Compnents[DamagedComp].transform.gameObject.GetComponent<Renderer>().material.color == new Color(1.0f, 0.39f, 0.0f, 1))
                        {
                            Compnents[DamagedComp].transform.gameObject.GetComponent<Renderer>().material.color = Color.green;
                            Debug.Log("100% Health");
                            break;
                        }
                    }
                }
            }
        }
    }
}