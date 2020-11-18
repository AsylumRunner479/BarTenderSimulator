using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Underdrunk.GameManagement
{
    public class OrderBehaviours : MonoBehaviour
    {
        public Text orderText;
        public Text timeText;
        public List<string> possibleOrders = new List<string>();
        public string order;
        float orderTimeStamp;


        private void Start()
        {
            orderTimeStamp = Time.time;
            order = possibleOrders[Random.Range(0, possibleOrders.Count - 1)];
            orderText.text = "Order: " + order;
            if (timeText)
            {
                timeText.text = "Time: " + 0;
            }
        }

        private void Update()
        {
            if (timeText)
            {
                int timeSinceOrder = (int)(Time.time - orderTimeStamp);
                timeText.text = "Time: " + timeSinceOrder.ToString();
            }
        }
    }
}