using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderController : MonoBehaviour
{
    [SerializeField] private Material material;

    private void Update()
    {
        material.SetFloat("_SplitValue", Mathf.Sin(Time.time));
    }
}