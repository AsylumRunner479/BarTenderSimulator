using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VrControllerInput))]
public class InteractGrab : MonoBehaviour
{
    private VrControllerInput input;
    public InteractionEvent grabbed = new InteractionEvent();
    public InteractionEvent notgrabbed = new InteractionEvent();

    private InteractableObject collidingObject;
    private InteractableObject heldObject;
    // Start is called before the first frame update
    void Start()
    {
        input = gameObject.GetComponent<VrControllerInput>();
        input.onGrabbed.AddListener(OnGrabPressed);
        input.onNotGrabbed.AddListener(OnGrabNotPressed);
    }
    private void OnGrabPressed(InputEventArgs _args)
    {
        if (collidingObject != null)
        {
            GrabObject();
        }
    }
    private void OnGrabNotPressed(InputEventArgs _args)
    {
        if (heldObject != null)
        {
            NotGrabObject();
        }
    }

    private void SetCollidingObject(Collider _collider)
    {
        InteractableObject interactable = _collider.GetComponent<InteractableObject>();
        if (collidingObject != null || interactable == null)
        {
            return;
        }
        collidingObject = interactable;
    }
    private void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }
    private void GrabObject()
    {
        heldObject = collidingObject;
        collidingObject = null;

        FixedJoint joint = AddJoint();
        joint.connectedBody = heldObject.Rigidbody;
        if (heldObject.AttachPoint != null)
        {
            heldObject.transform.position = transform.position - (heldObject.AttachPoint.position - heldObject.transform.position);
            heldObject.transform.rotation = transform.rotation * Quaternion.Euler(heldObject.AttachPoint.localEulerAngles);
        }
        else
        {
            heldObject.transform.position = transform.position;
        }
        grabbed.Invoke(new InteractionEventArgs(input.Controller, heldObject.Rigidbody, heldObject.Collider));
        heldObject.OnObjectGrabbed(input.Controller);
    }
    private void NotGrabObject()
    {
        FixedJoint joint = gameObject.GetComponent<FixedJoint>();
        if (joint != null)
        {
            joint.connectedBody = null;
            Destroy(joint);
            heldObject.Rigidbody.velocity = input.Controller.Velocity;
            heldObject.Rigidbody.angularVelocity = input.Controller.AngularVelocity;
        }

        notgrabbed.Invoke(new InteractionEventArgs(input.Controller, heldObject.Rigidbody, heldObject.Collider));
        heldObject.OnObjectNotGrabbed(input.Controller);
        heldObject = null;

    }
    private FixedJoint AddJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }
    private void OnTriggerExit(Collider other)
    {
        if (collidingObject == other.GetComponent<InteractableObject>())
        {
            collidingObject = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
