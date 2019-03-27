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
    public string health;
    void Start()
    {
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
                        if (hitval == Random.Range(minval,maxval))
                        {
                            Debug.Log("Hit");
                            Handheld.Vibrate();
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
}
