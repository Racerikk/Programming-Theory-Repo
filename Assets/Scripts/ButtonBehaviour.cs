using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void SetDifficulty(float SpawnInterval)
    {
        MainManager.Instance.spawnInterval = SpawnInterval;
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
