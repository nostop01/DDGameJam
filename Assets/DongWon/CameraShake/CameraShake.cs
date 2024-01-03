using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Camera Cam;
    Vector3 CameraOriginalPos;

    private void Start()
    {
        Cam = Camera.main;
        CameraOriginalPos = Cam.transform.position;
    }

    public IEnumerator CamShake(float duration, float magnitude)
    {
        float timer = 0;

        while(timer <= duration)
        {
            Cam.transform.localPosition = Random.insideUnitSphere * magnitude + CameraOriginalPos;

            timer += Time.deltaTime;
            yield return null;
        }

        Cam.transform.localPosition = CameraOriginalPos;
    }
} 
