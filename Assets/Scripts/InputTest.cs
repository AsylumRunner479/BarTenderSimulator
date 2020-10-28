using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class InputTest : MonoBehaviour
{
    public void OnGrabbed(InputEventArgs _args)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);

        go.transform.position = Random.insideUnitSphere * 2f;
    }
}
