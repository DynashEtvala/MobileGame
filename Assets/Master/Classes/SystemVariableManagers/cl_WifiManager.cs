using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class cl_WifiManager {

    public static bool IsWifiEnabled()
    {
        if(deviceWifi == null)
        {
            Debug.LogWarning("Failed to initialize WifiManager. Are you on Android?");
            return false;
        }
        return deviceWifi.Call<bool>("isWifiEnabled");
    }

    private static AndroidJavaObject wifiManager;

    private static AndroidJavaObject deviceWifi
    {
        get
        {
            try
            {
                if (wifiManager == null)
                {
                    AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                    AndroidJavaObject context = up.GetStatic<AndroidJavaObject>("currentActivity");

                    wifiManager = context.Call<AndroidJavaObject>("getSystemService", "wifi");
                }
                return wifiManager;
            }
            catch
            {
                Debug.LogWarning("Failed to initialize AudioManager. Are you on Android?");
                return null;
            }
        }
    }
}
