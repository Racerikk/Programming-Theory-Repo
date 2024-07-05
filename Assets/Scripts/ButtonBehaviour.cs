using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI announcementText;
    public void StartNew()
    {
        if(MainManager.Instance.playerName.Length > 3)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            ShowMenuAnnouncementMessage("Name 2 short");
        }
        
    }
    public void SetDifficulty(float SpawnInterval)
    {
        MainManager.Instance.spawnInterval = SpawnInterval;
        MainManager.Instance.scoreAddTimer = SpawnInterval*3;
    }
    public void ExitGame()
    {
        MainManager.Instance.SaveDataMethod();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator ShowMenuAnnouncementMessage(string message)
    {
        announcementText.gameObject.SetActive(true);
        announcementText.text = message;
        yield return new WaitForSeconds(2);
        announcementText.gameObject.SetActive(false);
    }

    public void WipeSaveData()
    {
        MainManager.Instance.highScore = 0;
        MainManager.Instance.highscorerName = null;
        MainManager.Instance.SaveDataMethod();
        ShowMenuAnnouncementMessage("Score data wiped! (There is no going back now)");
    }
}
