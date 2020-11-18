using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourAmount : MonoBehaviour
{
    public ParticleSystem particle;
    public float PourSpeed, maxPourSpeed, currentPour;
    public bool TapOn;
    public LiquidFill liquid;
    public MeshRenderer Mesh;
    public Material material;
    public string LiquidType;
    public void ChangePour(float tap)
    {
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
        liquid = other.GetComponent<LiquidFill>();
        if (liquid != null)
        {
            liquid.FillLiquid();
        }
        if (liquid.fillAmount >= liquid.maxfill)
        {
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
        if (TapOn)
        {
            currentPour += 10*Time.deltaTime;
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
        else
        {
            currentPour -= 20*Time.deltaTime;
            ChangePour(currentPour);
        }
        var rate = particle.emission;
        rate.rateOverTime = PourSpeed;
    }
}
