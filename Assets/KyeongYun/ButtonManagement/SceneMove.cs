using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public string sceneName;
    public void SceneMover()
    {
        SceneManager.LoadScene(sceneName);
    }
}
