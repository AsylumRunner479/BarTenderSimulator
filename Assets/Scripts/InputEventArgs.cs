using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[System.Serializable]
public class InputEventArgs
{
    public VrController controller;
    public SteamVR_Input_Sources source;
    public Vector2 touchpadAxis;
    public InputEventArgs(VrController _controller, SteamVR_Input_Sources _sources, Vector2 _touchpadAxis)
    {
        controller = _controller;
        source = _sources;
        touchpadAxis = _touchpadAxis;
    }
}
