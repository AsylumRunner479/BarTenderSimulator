using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Underdrunk.GameManagement
{
    public class SpawnFullMug : MonoBehaviour
    {
        [SerializeField] GameObject mugPrefab;
        public Transform spawnPos;
        public string liquidName;

        public void SpawnFullMugFunction()
        {
            LiquidFill newMug = Instantiate(mugPrefab.GetComponent<LiquidFill>());
            newMug.transform.position = spawnPos.position;
            newMug.full = true;
            newMug.LiquidType = liquidName;
        }
    }
}