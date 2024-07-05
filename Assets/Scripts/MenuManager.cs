using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI NameInputText;
    [SerializeField] TextMeshProUGUI highScoreText;

    private void Start()
    {
        if(MainManager.Instance.highScore != 0)
        {
            highScoreText.text = "High Score: " + MainManager.Instance.highscorerName + " : " + MainManager.Instance.highScore;
        }
        else
        {
            highScoreText.text = "No high score yet :(";
        }
        
    }
    void Update()
    {
        MainManager.Instance.playerName = NameInputText.text;
    }
}
