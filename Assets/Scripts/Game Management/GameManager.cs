using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Underdrunk.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameObject orderButtonPrefab;
        public List<OrderBehaviours> currentOrders = new List<OrderBehaviours>();
    }
}