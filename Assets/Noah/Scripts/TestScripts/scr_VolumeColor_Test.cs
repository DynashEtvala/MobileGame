﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_VolumeColor_Test : MonoBehaviour
{
    int hold;

    // Use this for initialization
    void Start()
    {
        hold = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.color = new Color(scr_SystemVariableController.Volume_Percent, scr_SystemVariableController.Volume_Percent, scr_SystemVariableController.Volume_Percent);
    }
}