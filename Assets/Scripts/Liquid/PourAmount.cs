using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Underdrunk.GameManagement
{
    public class PourAmount : MonoBehaviour
    {
        //the particle system that emits particles
        public ParticleSystem particle;
        //how fast it is pouring and how fast is the max pour
        public float PourSpeed, maxPourSpeed, currentPour;
        //whether the tap is on or not
        public bool TapOn;
        //what is the liquid being affected
        public LiquidFill liquid;
        //what is the mesh that can be affected
        public MeshRenderer Mesh;
        //what is the material(color) of the liquid
        public Material material;
        //what is the name of the liquid coming out of particle system
        public string LiquidType;
        public void ChangePour(float tap)
        {
            //increase the tap speed up to a limit and decrease it till it hits 0
            if (tap != PourSpeed)
            {
                if (tap <= maxPourSpeed)
                {
                    PourSpeed = tap;
                }
                else if (tap <= 0)
                {
                    PourSpeed = 0;
                }
                else
                {
                    PourSpeed = maxPourSpeed;
                }
            }
        }
        private void OnParticleCollision(GameObject other)
        {
            //increases the fill amount of a liquid whilst altering the material to fit this material
            liquid = other.GetComponent<LiquidFill>();
            if (liquid != null)
            {
                liquid.FillLiquid();
            }
            if (liquid.fillAmount >= liquid.maxfill)
            {
                //when the cup is full bounces materials everywhere
                var bouncy = particle.collision;
                bouncy.bounce = 1;
                bouncy.dampen = 0;
            }
            Mesh = other.GetComponent<MeshRenderer>();

            Mesh.material = material;
            liquid.LiquidType = LiquidType;
        }
        private void Update()
        {
            //when tap is on increase current pour
            if (TapOn)
            {
                currentPour += 10 * Time.deltaTime;
                ChangePour(currentPour);
            }
            else if (currentPour <= 0)
            {
                currentPour = 0;
                ChangePour(currentPour);
            }
            else if (currentPour >= maxPourSpeed)
            {
                currentPour = maxPourSpeed - 1;
                ChangePour(currentPour);
            }
            //decreases the current pour when the tap is off
            else
            {
                currentPour -= 20 * Time.deltaTime;
                ChangePour(currentPour);
            }
            //sets the particle emission based on the pour speed
            var rate = particle.emission;
            rate.rateOverTime = PourSpeed;
        }
    }
}
