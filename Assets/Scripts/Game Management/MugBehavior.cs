using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Underdrunk.GameManagement
{
    public class MugBehavior : MonoBehaviour
    {
        LiquidFill liquidFill;
        float gravity = 10;
        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.CompareTag("ServiceArea"))
            {
                GameManager.singleton.CheckOrder(liquidFill.LiquidType);
            }
        }
        private void Start()
        {
            liquidFill = GetComponent<LiquidFill>();
        }
        private void Update()
        {
            Vector3 pos = transform.position;
            pos.y -= (gravity * Time.deltaTime);
        }
    }
}