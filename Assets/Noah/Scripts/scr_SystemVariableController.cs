using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SystemVariableController : MonoBehaviour
{

    [SerializeField] static int? volume;
    [SerializeField] static int? volume_max;
    [SerializeField] static int? volume_min;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        volume = cl_VolumeManager.GetDeviceVolume();
        volume_max = cl_VolumeManager.GetDeviceMaxVolume();
        volume_min = cl_VolumeManager.GetDeviceMinVolume();
    }

    // Properties

    public static int Volume
    {
        get
        {
            if (volume == null)
            {
                volume = cl_VolumeManager.GetDeviceVolume();
            }
            return (int)volume;
        }
    }

    public static int Volume_Max
    {
        get
        {
            if (volume_max == null)
            {
                volume_max = cl_VolumeManager.GetDeviceMaxVolume();
            }
            return (int)volume_max;
        }
    }

    public static int VolumeMin
    {
        get
        {
            if (volume_min == null)
            {
                volume_min = cl_VolumeManager.GetDeviceMinVolume();
            }
            return (int)volume_min;
        }
    }
}
