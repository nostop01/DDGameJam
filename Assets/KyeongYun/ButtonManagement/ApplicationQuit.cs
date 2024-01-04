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
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
