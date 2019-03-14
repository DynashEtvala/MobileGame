using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cl_GlobalSettingsManager : MonoBehaviour
{
    public static float GetScreenBrightness()
    {
        using (var actClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            var context = actClass.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass systemGlobal = new AndroidJavaClass("android.provider.Settings$System");

            return systemGlobal.CallStatic<int>("getInt", context.Call<AndroidJavaObject>("getContentResolver"), "screen_brightness") / 255.0f;
        }
    }
}