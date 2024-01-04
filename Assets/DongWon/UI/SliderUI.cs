using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour
{
    public Slider Speedslider;

    [SerializeField]
    private float Speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Speed = PlayerMovement.Acceleration;

        Speedslider.value = Speed / PlayerMovement.MaxAcceleration;
    }
}
