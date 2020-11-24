﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class VrHelper : MonoBehaviour
{
    private static List<XRDisplaySubsystem> displays = new List<XRDisplaySubsystem>();
    public GameObject computerCamera;
    public GameObject vrCamera;

    public static void SetEnabled(bool _enabled)
    {
        displays.Clear();
        SubsystemManager.GetInstances(displays);

        foreach(XRDisplaySubsystem system in displays)
        {
            if(_enabled)
            {
                system.Start();
            }
            else
            {
                system.Stop();
            }
        }
    }

    public static bool IsEnabled()
    {
        displays.Clear();
        SubsystemManager.GetInstances(displays);

        foreach (XRDisplaySubsystem system in displays)
        {
            if (system.running)
            {
                return true;
            }
        }

        return false;
    }

    private void Start()
    {
        if(IsEnabled())
        {
            vrCamera.SetActive(true);
        }
        else
        {
            computerCamera.SetActive(true);
        }
    }
}
