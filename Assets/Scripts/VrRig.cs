using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrRig : MonoBehaviour
{
    public static VrRig instance = null;

    public Transform Headset { get { return headset; } }
    public Transform LeftController { get { return leftController; } }
    public Transform RightController { get { return rightController; } }

    [SerializeField]
    private Transform headset;
    [SerializeField]
    private Transform leftController;
    [SerializeField]
    private Transform rightController;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }


}
