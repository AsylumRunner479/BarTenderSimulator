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
        public float orderDelay;
        public float orderDelayMin;
        public float orderDelayMax;
        public float orderDelayModifier;
        public float previousOrdertimeStamp;
        #endregion

        #region Game Management
        public int playerScore;
        #endregion

        void AddRandomOrder()
        {
            OrderBehaviours newOrder = Instantiate(orderButtonPrefab, orderDisplayPanel).GetComponent<OrderBehaviours>();
            currentOrders.Add(newOrder);
            previousOrdertimeStamp = Time.time;
            orderDelay = Random.Range(orderDelayMin, orderDelayMax);
        }

        public void CheckOrder(string servedOrderType)
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

        private void Start()
        {
            orderDelay = Random.Range(orderDelayMin, orderDelayMax);
        }

        private void Update()
        {
            if (Time.time - previousOrdertimeStamp > orderDelay)
            {
                AddRandomOrder();
            }
        }
    }
}