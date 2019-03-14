using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SystemVariableController : MonoBehaviour
{

    [SerializeField] static int? volume;
    [SerializeField] static int? volume_max;
    [SerializeField] static int? volume_min;
    [SerializeField] static float? screen_brightness;
    [SerializeField] static bool? wifi_enabled;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        volume = null;
        volume_max = null;
        volume_min = null;
        screen_brightness = null;
        wifi_enabled = null;
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

    public static float Volume_Percent
    {
        get
        {
            return (float)Volume / Volume_Max;
        }
    }

    public static float Screen_Brightness
    {
        get
        {
            if(screen_brightness == null)
            {
                screen_brightness = cl_GlobalSettingsManager.GetScreenBrightness();
            }
            return (float)screen_brightness;
        }
    }

    public static bool Wifi_Enabled
    {
        get
        {
            if (wifi_enabled == null)
            {
                wifi_enabled = cl_WifiManager.IsWifiEnabled();
            }
            return (bool)wifi_enabled;
        }
    }
}
