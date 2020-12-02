using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Underdrunk.GameManagement
{
    public class MugBehavior : MonoBehaviour
    {
        LiquidFill liquidFill;
        float gravity = 2;
        bool falling = true;
        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.CompareTag("ServiceArea"))
            {
                GameManager.singleton.CheckOrder(liquidFill.LiquidType);
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            falling = false;
        }
        private void OnCollisionExit(Collision collision)
        {
            falling = true;
        }
        private void Start()
        {
            liquidFill = GetComponent<LiquidFill>();
        }
        private void Update()
        {
            if (falling)
            {
                Vector3 pos = transform.position;
                pos.y -= (gravity * Time.deltaTime);
                transform.position = pos;
            }
        }
    }
}