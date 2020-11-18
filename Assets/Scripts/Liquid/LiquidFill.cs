﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Underdrunk.GameManagement
{
    public class LiquidFill : MonoBehaviour
    {

        public GameObject MugTop, MugBottom, self;
        public float fillAmount, maxfill = 1000;
        public bool full;
        public string LiquidType;
        // Start is called before the first frame update
        void Start()
        {
            fillAmount = 1;
        }

        public void FillLiquid()
        {
            if (fillAmount >= maxfill)
            {
                full = true;
            }
            if (fillAmount <= maxfill)
            {
                fillAmount += 1;
            }

        }
        // Update is called once per frame
        void Update()
        {


            self.transform.position = Vector3.Lerp(MugBottom.transform.position, MugTop.transform.position, Mathf.Clamp01(fillAmount / maxfill));

        }
    }
}