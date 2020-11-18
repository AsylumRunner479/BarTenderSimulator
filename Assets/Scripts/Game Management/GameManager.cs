using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Underdrunk.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        #region Orders
        [SerializeField] Transform orderDisplayPanel;
        [SerializeField] GameObject orderButtonPrefab;
        public List<OrderBehaviours> currentOrders = new List<OrderBehaviours>();
        #endregion

        void AddOrder()
        {
            OrderBehaviours newOrder = Instantiate(orderButtonPrefab, orderDisplayPanel).GetComponent<OrderBehaviours>();
            currentOrders.Add(newOrder);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                AddOrder();
            }
        }
    }
}