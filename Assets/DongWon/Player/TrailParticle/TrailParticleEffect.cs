using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailParticleEffect : MonoBehaviour
{
    public ParticleSystem TrailParticleSystem;

    public float TrailSpeed;
    public float RateTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TrailSpeed = PlayerMovement.MoveSpeed / 110f;
        RateTime = PlayerMovement.MoveSpeed * 3.5f;

        TrailParticle();
    }

    private void TrailParticle()
    {
        ParticleSystem.MainModule mainModule = TrailParticleSystem.main;
        ParticleSystem.EmissionModule emssionModule = TrailParticleSystem.emission;

        // StartLifetime 값을 수정합니다.
        mainModule.startLifetime = TrailSpeed;
        emssionModule.rateOverTime = RateTime;
    }
}
