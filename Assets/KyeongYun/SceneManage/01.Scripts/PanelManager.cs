using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject panel;
    
    public void PanelActive()
    {
        panel.SetActive(true);
    }
    public void PanelDeActivate()
    {
        panel.SetActive(false);
    }
    public void OnApplicationQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
