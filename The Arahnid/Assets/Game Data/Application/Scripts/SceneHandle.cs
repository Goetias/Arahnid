using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandle : MonoBehaviour
{
    public static SceneHandle Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }


    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void SelectScene(int number)
    {
        SceneManager.LoadScene(number);
    }
}
