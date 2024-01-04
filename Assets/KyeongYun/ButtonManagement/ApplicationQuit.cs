using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationQuit : MonoBehaviour
{
    public void OnApplicationQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }
}
