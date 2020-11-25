using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Underdrunk.GameManagement
{
    public class GameManagerInitializer : MonoBehaviour
    {
        public void StartGame()
        {
            GameManager.singleton.enabled = true;
        }


    }
}