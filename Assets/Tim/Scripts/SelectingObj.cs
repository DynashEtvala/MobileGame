using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectingObj : MonoBehaviour
{
    int minval = 1;
    public int maxval;
    public int hitval;
    public Camera cam;
    public List<string> tagValue;
    public List<GameObject> differentComps;
    public int health;
    void Start()
    {
        for(int t = 0; t < differentComps.Count; t++)
        {
            differentComps[t].transform.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 touchPosFar = new Vector3(Input.mousePosition.x,Input.mousePosition.y,cam.farClipPlane);
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
                        int randHitVal = Random.Range(minval, maxval + 1);
                        if (hitval == randHitVal)
                        {
                            Debug.Log("Hit");
                            int randDmg = Random.Range(1, 100);
                            health = health - randDmg;
                            int randomComp = Random.Range(0, differentComps.Count + 1);
                            Handheld.Vibrate();
                            if (health < 100)
                            {
                                if (differentComps[randomComp].transform.gameObject.GetComponent<Renderer>().material.color == Color.green)
                                {
                                    differentComps[randomComp].transform.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.39f, 0.0f,1);
                                    break;
                                }
                                if (differentComps[randomComp].transform.gameObject.GetComponent<Renderer>().material.color == new Color(1.0f, 0.39f, 0, 1))
                                {
                                    differentComps[randomComp].transform.gameObject.GetComponent<Renderer>().material.color = Color.red;
                                    break;
                                }
                                if (differentComps[randomComp].transform.gameObject.GetComponent<Renderer>().material.color == Color.red)
                                {
                                    differentComps[randomComp].transform.gameObject.GetComponent<Renderer>().material.color = Color.gray;
                                    break;
                                }
                                 
                            }
                           }
                        }
                        else
                        {
                            Debug.Log("Miss");
                        }
                }
            }
        }
    }

}
