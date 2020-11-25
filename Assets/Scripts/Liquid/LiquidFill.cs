using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Underdrunk.GameManagement
{
    public class LiquidFill : MonoBehaviour
    {
        //what is the top part of the mug, bottom part and where the liquid is relative to them
        public GameObject MugTop, MugBottom, self;
        //how much liquid is in the cup and how much liquid can be in the cup
        public float fillAmount, maxfill = 1000;
        //whether the cup is full or not
        public bool full;
        //what type of liquid is in the liquid
        public string LiquidType;
        // Start is called before the first frame update
        void Start()
        {
            //sets the liquid amount to 1
            fillAmount = 1;
        }

        public void FillLiquid()
        {
            //if the fill amount is high enough then register it as full
            if (fillAmount >= maxfill)
            {
                full = true;
            }
            //increases the fill amount slowly
            if (fillAmount <= maxfill)
            {
                fillAmount += 1;
            }

        }
        // Update is called once per frame
        void Update()
        {

            //makes the liquid move closer to the top/ further from the bottom
            self.transform.position = Vector3.Lerp(MugBottom.transform.position, MugTop.transform.position, Mathf.Clamp01(fillAmount / maxfill));

        }
    }
}
