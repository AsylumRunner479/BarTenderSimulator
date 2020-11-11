using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.Events;
public class Pointer : MonoBehaviour
{
    public Vector3 Position { get; private set; }
    public class TeleporterEvent : UnityEvent<Vector3> 
    { 

    }
    [SerializeField]
    private SteamVR_Input_Sources source;
    private float maxPointerLength;
    private LayerMask PointerLayers;
    [Header("Rendering")]
    [SerializeField]
    private GameObject tracer;
    [SerializeField]
    private bool strtchTracerAlongRay = true;
    [SerializeField]
    private float tracerScaleFactor = 0.1f;
    [SerializeField]
    private GameObject cursor;
    [SerializeField]
    private float cursorScaleFactor = 0.25f;
    private VrControllerInput input;
    private bool isPointerActive = false;
    public TeleporterEvent BeamMeUpScotty = new TeleporterEvent ();
    // Start is called before the first frame update
    void Start()
    {
        if (source == SteamVR_Input_Sources.LeftHand)
        {
            input = VrRig.instance.LeftController.Input;
        }
        else if (source == SteamVR_Input_Sources.RightHand)
        {
            input = VrRig.instance.LeftController.Input;
        }
        else
        {
            input = VrRig.instance.LeftController.Input;
        }
        input.onPointer.AddListener(OnPointerActivate);
        input.onNotPointer.AddListener(OnPointerNotActivate);
        input.onTeleport.AddListener(OnTeleportNotNotPressed);

        tracer.transform.parent = transform;
        cursor.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = input.transform.rotation;
        if (isPointerActive)
        {
            if (Physics.Raycast(input.transform.position, input.transform.forward, out RaycastHit hit, maxPointerLength, PointerLayers))
            {
                Position = hit.point;

                Vector3 midpoint = Vector3.Lerp(transform.position, hit.point, 0.5f);
                tracer.transform.position = midpoint;
                tracer.transform.rotation = Quaternion.LookRotation(transform.forward);
                tracer.transform.localScale = new Vector3(tracerScaleFactor, tracerScaleFactor, hit.distance);

                cursor.transform.position = hit.point;
                cursor.transform.localScale = Vector3.one * cursorScaleFactor;
            }
            else
            {
                Position = Vector3.zero;
                tracer.transform.position = transform.position + transform.forward * (maxPointerLength * 0.5f);
                tracer.transform.rotation = Quaternion.LookRotation(transform.forward);
                tracer.transform.localScale = new Vector3(tracerScaleFactor, tracerScaleFactor, maxPointerLength);

                cursor.transform.position = transform.position + transform.forward * maxPointerLength;
                cursor.transform.localScale = Vector3.one * cursorScaleFactor;
            }
        }
    }
    private void OnPointerActivate(InputEventArgs _args)
    {
        isPointerActive = true;
        tracer.SetActive(true);
        cursor.SetActive(true);
    }
    private void OnPointerNotActivate(InputEventArgs _args)
    {
        isPointerActive = false;
        tracer.SetActive(false);
        cursor.SetActive(false);
    }
    private void OnTeleportNotNotPressed(InputEventArgs _args)
    {
        if (isPointerActive)
        {
            BeamMeUpScotty.Invoke(Position);
        }
    }
}
