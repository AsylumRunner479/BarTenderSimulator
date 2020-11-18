using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Underdrunk.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        //#region Singleton
        //GameManager singleton;
        //GameManager Singleton
        //{
        //    get
        //    {
        //        if(singleton == null)
        //        {
        //            singleton = this;
        //        }
        //        else
        //        {
        //            Destroy(gameObject);
        //        }
        //        return singleton;
        //    }
        //}
        //#endregion

        #region Orders
        [SerializeField] Transform orderDisplayPanel;
        [SerializeField] GameObject orderButtonPrefab;
        public List<OrderBehaviours> currentOrders = new List<OrderBehaviours>();
        #endregion

        #region Service
        [SerializeField] GameObject serviceArea;
        #endregion

        #region Game Management
        public int playerScore;
        #endregion

        void AddOrder()
        {
            OrderBehaviours newOrder = Instantiate(orderButtonPrefab, orderDisplayPanel).GetComponent<OrderBehaviours>();
            currentOrders.Add(newOrder);
        }

        void CheckOrder(string servedOrderType)
        {
            //check each order that is currently active
            foreach (OrderBehaviours order in currentOrders)
            {
                if(order.orderType == servedOrderType)//if the 
                {
                    //remove reference to button in the list
                    currentOrders.Remove(order);
                    //destroy the button that has the order
                    Destroy(order.gameObject);
                    //add to players score
                    playerScore++;
                    return;
                }
            }
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                AddOrder();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                OrderBehaviours tempOrder = currentOrders[Random.Range(0, currentOrders.Count - 1)];
                RemoveOrder(tempOrder);
            }
        }
    }
}