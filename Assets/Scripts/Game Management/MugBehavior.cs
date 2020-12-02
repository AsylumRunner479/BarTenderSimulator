using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Underdrunk.GameManagement
{
    public class MugBehavior : MonoBehaviour
    {
        LiquidFill liquidFill;
        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.CompareTag("ServiceArea"))
            {
                GameManager.singleton.CheckOrder(liquidFill.LiquidType);
                Destroy(gameObject);
            }
        }
        private void Start()
        {
            liquidFill = GetComponent<LiquidFill>();
        }
    }
}