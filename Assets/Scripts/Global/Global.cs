using System;
using UnityEngine;
using System.Runtime.InteropServices;

public enum GameDevice
{
    PC,
    Mobile
}

public static class Global
{
    public static GameDevice IsMobile { get; private set; }

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern int IsMobileDevice();
#endif

    public static void Init()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        IsMobile = IsMobileDevice() == 1 ? GameDevice.Mobile : GameDevice.PC;
#else
        IsMobile = Application.isMobilePlatform ? GameDevice.Mobile : GameDevice.PC;
#endif

        Debug.Log($"[Global] Device: {IsMobile.ToString()}");
    }
}