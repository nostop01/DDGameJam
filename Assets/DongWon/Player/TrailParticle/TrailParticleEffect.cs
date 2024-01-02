using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailParticleEffect : MonoBehaviour
{
    public ParticleSystem TrailParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TrailParticle();
    }

    private void TrailParticle()
    {
        if(PlayerMovement.MoveSpeed >= 80f)
        {
            TrailParticleSystem.Play();

            Debug.Log("True");
        }

        else
        {
            
        }
    }
}
