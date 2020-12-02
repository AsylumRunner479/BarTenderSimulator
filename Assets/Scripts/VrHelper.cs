using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class VrHelper : MonoBehaviour
{
    private static List<XRDisplaySubsystem> displays = new List<XRDisplaySubsystem>();
    public int pcScene = 1, vrScene = 2;
    public static bool isPresent()
    {
        var xrDisplaySubsystems = new List<XRDisplaySubsystem>();
        SubsystemManager.GetInstances<XRDisplaySubsystem>(xrDisplaySubsystems);
        foreach (var xrDisplay in xrDisplaySubsystems)
        {
            if (xrDisplay.running)
            {
                return true;
            }
        }
        return false;
    }

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
    public void ButtonFunction()
    {
        if (isPresent())
        {
            SceneManager.LoadScene(vrScene);
        }
        else
        {
            SceneManager.LoadScene(pcScene);
        }
    }
}
