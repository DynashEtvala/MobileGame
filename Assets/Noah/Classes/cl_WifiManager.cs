using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cl_WifiManager : MonoBehaviour {

    public static bool IsWifiEnabled()
    {
        return deviceWifi.Call<bool>("isWifiEnabled");
    }

    private static AndroidJavaObject wifiManager;

    private static AndroidJavaObject deviceWifi
    {
        get
        {
            if (wifiManager == null)
            {
                AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject context = up.GetStatic<AndroidJavaObject>("currentActivity");

                wifiManager = context.Call<AndroidJavaObject>("getSystemService", "wifi");
            }
            return wifiManager;
        }
    }
}
