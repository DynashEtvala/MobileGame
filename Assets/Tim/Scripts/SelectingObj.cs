using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectingObj : MonoBehaviour
{
    public int minval;
    public int maxval;
    public int hitval;
    private int randVal;
    public List<GameObject> cube;
    GameObject obj;
    public Camera cam;
    public string tagValue;
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
                if (hit.transform.gameObject.tag == tagValue)
                    {
                        Debug.Log(tagValue + "On");
                        hit.transform.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Random.ColorHSV());
                    }
                
            }
        }

     }
}

        //if (Input.touchCount > 0)
        //{
        //    touch = Input.GetTouch(0);
        //    Debug.DrawRay(touch.position, transform.forward);
        //    if (Physics.Raycast(ray, out hit, 100.0f))
        //    {
        //        Debug.Log("HIT");
        //    }
        //}
