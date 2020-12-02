using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Underdrunk.GameManagement
{
    public class ServiceArea : MonoBehaviour
    {
        GameManager gameManager;

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("served order");
            OrderBehaviours servedOrder = collision.gameObject.GetComponent<OrderBehaviours>();
            if (servedOrder != null)
            {
                Debug.Log("served order");
                gameManager.CheckOrder(servedOrder.orderType);
            }
        }

        public void ServeButtonFunction()
        {
            GameObject[] mugs = GameObject.FindGameObjectsWithTag("Mug");

            foreach(GameObject mug in mugs)
            {
                GameManager.singleton.CheckOrder(mug.GetComponent<LiquidFill>().LiquidType);
                Destroy(mug);
            }
        }
    }
}