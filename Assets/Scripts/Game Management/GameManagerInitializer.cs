using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Underdrunk.GameManagement
{
    public class GameManagerInitializer : MonoBehaviour
    {
        public float initialDelay;
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
                GameManager.singleton.enabled = true;
            }
        }
    }
}