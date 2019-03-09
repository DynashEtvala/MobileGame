using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_VolumeColor_Test : MonoBehaviour {
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Material>().color = new Color(0.5f, (float)scr_SystemVariableController.Volume / scr_SystemVariableController.Volume_Max, (float)scr_SystemVariableController.Volume / scr_SystemVariableController.Volume_Max);
	}
}
