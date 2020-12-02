using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Underdrunk.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        public static GameManager singleton;
        private void Awake()
        {
            if(singleton == null)
            {
                singleton = this;
            }
            else if(singleton != this)
            {
                Destroy(gameObject);
                return;
            }
        }

        #endregion

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
        int timeLimit = 60;
        float gameStartTimeStamp;
        bool gameRunning = true;
        #endregion

        #region UI
        public Text timeDisplay, endScoreText;
        public GameObject endGameDisplayPanel;
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
            Debug.Log("check served order");
            //check each order that is currently active
            foreach (OrderBehaviours order in currentOrders)
            {
                if(order.orderType == servedOrderType)//if the 
                {
                    Debug.Log("served order found");
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

        void Quit()
        {
            Debug.Log("quit after time");

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }

        void EndGame()
        {
            Debug.Log("Game Over");
            gameRunning = false;
            foreach (var order in currentOrders)
            {
                Destroy(order.gameObject);
            }
            currentOrders.Clear();
            endScoreText.text = playerScore.ToString();
            orderDisplayPanel.gameObject.SetActive(false);
            endGameDisplayPanel.SetActive(true);
            Invoke("Quit", 5);
        }

        private void Start()
        {
            orderDelayMin = 3;
            orderDelayMax = 5;
            orderDelay = Random.Range(orderDelayMin, orderDelayMax);
            gameRunning = true;
            gameStartTimeStamp = Time.time;
        }

        private void Update()
        {
            int gameTime = (int)(timeLimit - (Time.time - gameStartTimeStamp));
            if (gameRunning)
            {
                timeDisplay.text = gameTime.ToString();
                if (gameTime <= 0)
                {
                    EndGame();
                }
                if (Time.time - previousOrdertimeStamp > orderDelay)
                {
                    AddRandomOrder();
                }
            }
        }
    }
}