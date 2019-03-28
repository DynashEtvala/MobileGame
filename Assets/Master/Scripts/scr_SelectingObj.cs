using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SelectingObj : MonoBehaviour
{
    int minval = 1;
    public int maxval;
    public int hitval;
    public Camera cam;
    public List<string> tagValue;
    public List<GameObject> Compnents;
    public int health;
    void Start()
    {
        for (int t = 0; t < Compnents.Count; t++)
        {
            Compnents[t].transform.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 touchPosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.farClipPlane);
            Vector3 touchPosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane);
            Vector3 touchPosF = cam.ScreenToWorldPoint(touchPosFar);
            Vector3 touchPosN = cam.ScreenToWorldPoint(touchPosNear);
            RaycastHit hit;

            if (Physics.Raycast(touchPosN, touchPosF - touchPosN, out hit))
            {
                for (int i = 0; i < tagValue.Capacity; i++)
                {
                    if (hit.transform.gameObject.tag == tagValue[i] && tagValue[i] != "Fire")
                    {
                        switch (tagValue[i])
                        {
                            case "Sensor":
                                Debug.Log("Sensors Online");
                                hit.transform.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Random.ColorHSV());
                                break;
                            case "Targeting":
                                Debug.Log("Targeting Onlne");
                                hit.transform.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Random.ColorHSV());
                                break;
                            case "Health":
                                Debug.Log("Your Health Is:" + health);
                                hit.transform.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Random.ColorHSV());
                                break;
                        }
                    }
                    if (hit.transform.gameObject.tag == tagValue[i] && tagValue[i] == "Fire")
                    {
                        int randHitVal = Random.Range(minval, maxval);
                        if (hitval == randHitVal)
                        {
                            Debug.Log("Hit");
                            health = health - 4;
                            int randomComp = Random.Range(0, Compnents.Count);
                            Debug.Log(randomComp);
                            Handheld.Vibrate();
                            if (health < 1000)
                            {
                                if (Compnents[randomComp].transform.gameObject.GetComponent<Renderer>().material.color == Color.green)
                                {
                                    Compnents[randomComp].transform.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.39f, 0.0f, 1);
                                    break;
                                }
                                if (Compnents[randomComp].transform.gameObject.GetComponent<Renderer>().material.color == new Color(1.0f, 0.39f, 0, 1))
                                {
                                    Compnents[randomComp].transform.gameObject.GetComponent<Renderer>().material.color = new Color(0.59f, 0.0f, 0, 1);
                                    break;
                                }
                                if (Compnents[randomComp].transform.gameObject.GetComponent<Renderer>().material.color == new Color(0.59f, 0.0f, 0, 1))
                                {
                                    Compnents[randomComp].transform.gameObject.GetComponent<Renderer>().material.color = Color.black;
                                    break;
                                }
                                if (Compnents[randomComp].transform.gameObject.GetComponent<Renderer>().material.color == Color.black)
                                {
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
                    if (hit.transform.gameObject.tag == tagValue[i] && tagValue[i] == "Repair")
                    {
                        int DamagedComp = Random.Range(0, Compnents.Count);
                        if (Compnents[DamagedComp].transform.gameObject.GetComponent<Renderer>().material.color == Color.black)
                        {
                            Compnents[DamagedComp].transform.gameObject.GetComponent<Renderer>().material.color = new Color(0.59f, 0.0f, 0, 1);
                            break;
                        }
                        if (Compnents[DamagedComp].transform.gameObject.GetComponent<Renderer>().material.color == new Color(0.59f, 0.0f, 0, 1))
                        {
                            Compnents[DamagedComp].transform.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.39f, 0.0f, 1);
                            break;
                        }
                        if (Compnents[DamagedComp].transform.gameObject.GetComponent<Renderer>().material.color == new Color(1.0f, 0.39f, 0.0f, 1))
                        {
                            Compnents[DamagedComp].transform.gameObject.GetComponent<Renderer>().material.color = Color.green;
                            break;
                        }
                        else
                        {
                            Debug.Log("All Repaired");
                        }
                    }
                }
            }
        }
    }
}
