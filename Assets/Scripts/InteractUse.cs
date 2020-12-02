using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VrControllerInput))]
public class InteractUse : MonoBehaviour
{
    private VrControllerInput input;
    public InteractionEvent use = new InteractionEvent();
    public InteractionEvent notUsed = new InteractionEvent();

    private InteractableObject collidingObject;
    private InteractableObject heldObject;
    // Start is called before the first frame update
    void Start()
    {
        input = gameObject.GetComponent<VrControllerInput>();
        input.onUse.AddListener(OnUsePressed);
        input.onNotUse.AddListener(OnUseNotPressed);
    }
    private void OnUsePressed(InputEventArgs _args)
    {
        if (collidingObject != null)
        {
            // use.Invoke(new InteractionEventArgs(input.Controller, heldObject.Rigidbody, heldObject.Collider));
            collidingObject.OnObjectUsed(input.Controller);
        }
    }
    private void OnUseNotPressed(InputEventArgs _args)
    {
        
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
