using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingEnergy : MonoBehaviour
{
    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ShaderControll();
    }

    private void ShaderControll()
    {
        float SplitValue = mat.GetFloat("_SplitValue");
        SplitValue = EnergyStatus.EnergyHealth / 100;

        mat.SetFloat("_SplitValue", SplitValue);
    }
}
