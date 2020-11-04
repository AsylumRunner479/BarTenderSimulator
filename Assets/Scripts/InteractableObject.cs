using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(Rigidbody))]
public class InteractableObject : MonoBehaviour
{
    public Rigidbody Rigidbody { get { return rigidbody; } }
    public Collider Collider { get { return collider; } }

    public Transform AttachPoint { get { return attachPoint; } }
    [SerializeField]
    private bool isGrabable = true;
    [SerializeField]
    private bool isTouchable = false;
    [SerializeField]
    private bool isUsable = false;
    [SerializeField]
    private SteamVR_Input_Sources allowedSource = SteamVR_Input_Sources.Any;
    public InteractionEvent OnGrabbed = new InteractionEvent();
    public InteractionEvent OnNotGrabbed = new InteractionEvent();
    public InteractionEvent OnTouched = new InteractionEvent();
    public InteractionEvent OnNotTouched = new InteractionEvent();
    public InteractionEvent OnUsed = new InteractionEvent();
    public InteractionEvent OnNotUsed = new InteractionEvent();
    private new Collider collider;
    private new Rigidbody rigidbody;
    private Transform attachPoint;
    private InteractionEventArgs GenerateArgs(VrController _controller)
    {
        return new InteractionEventArgs(_controller, rigidbody, collider);
    }
    private void Start()
    {
        collider = gameObject.GetComponent<Collider>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<BoxCollider>();
            Debug.LogErrorFormat("Object: {0} does not have a collider, adding a BoxCollider", name);
        }
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    public void OnObjectGrabbed(VrController _controller)
    {
        if (isGrabable && (_controller.InputSource == allowedSource || allowedSource == SteamVR_Input_Sources.Any))
        {
            OnGrabbed.Invoke(GenerateArgs(_controller));
        }
    }
    public void OnObjectNotGrabbed(VrController _controller)
    {
        if (isGrabable && (_controller.InputSource == allowedSource || allowedSource == SteamVR_Input_Sources.Any))
        {
            OnNotGrabbed.Invoke(GenerateArgs(_controller));
        }
    }
    public void OnObjectUsed(VrController _controller)
    {
        if (isUsable && (_controller.InputSource == allowedSource || allowedSource == SteamVR_Input_Sources.Any))
        {
            OnUsed.Invoke(GenerateArgs(_controller));
        }
    }
    public void OnObjectNotUsed(VrController _controller)
    {
        if (isUsable && (_controller.InputSource == allowedSource || allowedSource == SteamVR_Input_Sources.Any))
        {
            OnNotUsed.Invoke(GenerateArgs(_controller));
        }
    }
    public void OnObjectTouched(VrController _controller)
    {
        if (isTouchable && (_controller.InputSource == allowedSource || allowedSource == SteamVR_Input_Sources.Any))
        {
            OnTouched.Invoke(GenerateArgs(_controller));
        }
    }
    public void OnObjectNotTouched(VrController _controller)
    {
        if (isTouchable && (_controller.InputSource == allowedSource || allowedSource == SteamVR_Input_Sources.Any))
        {
            OnNotTouched.Invoke(GenerateArgs(_controller));
        }
    }
}
