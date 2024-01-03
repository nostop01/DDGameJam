using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailParticleEffect : MonoBehaviour
{
    public ParticleSystem TrailParticleSystem;

    public float Timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += 0.001f;

        if(Timer >= 2f) 
        {
            Timer = 2f;
        }

        TrailParticle();
    }

    private void TrailParticle()
    {
        ParticleSystem.MainModule mainModule = TrailParticleSystem.main;

        // StartLifetime 값을 수정합니다.
        mainModule.startLifetime = Timer;
    }
}
