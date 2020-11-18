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
        public List<string> possibleOrderTypes = new List<string>();
        public string orderType;
        float orderTimeStamp;


        private void Start()
        {
            orderTimeStamp = Time.time;
            orderType = possibleOrderTypes[Random.Range(0, possibleOrderTypes.Count - 1)];
            orderText.text = "Order: " + orderType;
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