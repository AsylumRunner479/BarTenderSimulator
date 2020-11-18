using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourAmount : MonoBehaviour
{
    public ParticleSystem particle;
    public float PourSpeed, maxPourSpeed, currentPour;
    public bool TapOn;

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
