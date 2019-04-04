using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Camera cam;
    cl_Ship_Player myShip;
    int volume;
    float brightness;
    bool wifiEnabled;
    public int currency;
    public int score;

	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update()
    {
        volume = scr_SystemVariableController.Volume;
        brightness = scr_SystemVariableController.Screen_Brightness;
        wifiEnabled = scr_SystemVariableController.Wifi_Enabled;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 touchPosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.farClipPlane);
            Vector3 touchPosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane);
            Vector3 touchPosF = cam.ScreenToWorldPoint(touchPosFar);
            Vector3 touchPosN = cam.ScreenToWorldPoint(touchPosNear);
            RaycastHit rayHit;

            if (Physics.Raycast(touchPosN, touchPosF - touchPosN, out rayHit))
            {

            }
        }
    }
}
