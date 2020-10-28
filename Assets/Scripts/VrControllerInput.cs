using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.Events;

public class VrControllerInput : MonoBehaviour
{
    [System.Serializable]
    public class InputEvent : UnityEvent<InputEventArgs> { }
    [SerializeField]
    private SteamVR_Action_Boolean grab;
    [SerializeField]
    private SteamVR_Action_Boolean pointer;
    [SerializeField]
    private SteamVR_Action_Boolean use;
    [SerializeField]
    private SteamVR_Action_Boolean teleport;
    [SerializeField]
    private SteamVR_Action_Vector2 touchpadAxis;

    public InputEvent onGrabbed = new InputEvent();
    public InputEvent onNotGrabbed = new InputEvent();

    public InputEvent onPointer = new InputEvent();
    public InputEvent onNotPointer = new InputEvent();

    public InputEvent onUse = new InputEvent();
    public InputEvent onNotUse = new InputEvent();

    public InputEvent onTeleport = new InputEvent();
    public InputEvent onNotTeleport = new InputEvent();

    public InputEvent onTouchpadAxis = new InputEvent();

    private VrController controller;

    public void Setup(VrController _controller)
    {
        controller = _controller;

        grab.AddOnStateDownListener(OnGrabDown, controller.InputSource);
        grab.AddOnStateUpListener(OnGrabUp, controller.InputSource);

        pointer.AddOnStateDownListener(OnPointerDown, controller.InputSource);
        pointer.AddOnStateUpListener(OnPointerUp, controller.InputSource);

        teleport.AddOnStateDownListener(OnTeleportDown, controller.InputSource);
        teleport.AddOnStateUpListener(OnTeleportUp, controller.InputSource);

        use.AddOnStateDownListener(OnUseDown, controller.InputSource);
        use.AddOnStateUpListener(OnUseUp, controller.InputSource);

        touchpadAxis.AddOnChangeListener(OnTouchpadAxisChanged, controller.InputSource);
        
    }
    private InputEventArgs GenerateArgs()
    {
        return new InputEventArgs(controller, controller.InputSource, touchpadAxis.axis);
    }
    private void OnGrabDown(SteamVR_Action_Boolean _action, SteamVR_Input_Sources _source)
    {
        onGrabbed.Invoke(GenerateArgs());
    }
    private void OnGrabUp(SteamVR_Action_Boolean _action, SteamVR_Input_Sources _source)
    {
        onNotGrabbed.Invoke(GenerateArgs());
    }
    private void OnPointerDown(SteamVR_Action_Boolean _action, SteamVR_Input_Sources _source)
    {
        onPointer.Invoke(GenerateArgs());
    }
    private void OnPointerUp(SteamVR_Action_Boolean _action, SteamVR_Input_Sources _source)
    {
        onNotPointer.Invoke(GenerateArgs());
    }
    private void OnUseDown(SteamVR_Action_Boolean _action, SteamVR_Input_Sources _source)
    {
        onUse.Invoke(GenerateArgs());
    }
    private void OnUseUp(SteamVR_Action_Boolean _action, SteamVR_Input_Sources _source)
    {
        onNotUse.Invoke(GenerateArgs());
    }
    private void OnTeleportDown(SteamVR_Action_Boolean _action, SteamVR_Input_Sources _source)
    {
        onTeleport.Invoke(GenerateArgs());
    }
    private void OnTeleportUp(SteamVR_Action_Boolean _action, SteamVR_Input_Sources _source)
    {
        onNotTeleport.Invoke(GenerateArgs());
    }
    private void OnTouchpadAxisChanged(SteamVR_Action_Vector2 _action, SteamVR_Input_Sources _source, Vector2 _axis, Vector2 _delta)
    {
        onTouchpadAxis.Invoke(GenerateArgs());
    }
   
}
