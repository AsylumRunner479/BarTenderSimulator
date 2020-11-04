using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InteractionEvent : UnityEvent<InteractionEventArgs> { }
[System.Serializable]
public class InteractionEventArgs
{
    public VrController controller;
    public Rigidbody rigidbody;
    public Collider collider;
    public InteractionEventArgs(VrController _controller, Rigidbody _rigidbody, Collider _collider)
    {
        controller = _controller;
        rigidbody = _rigidbody;
        collider = _collider;
    }
}
