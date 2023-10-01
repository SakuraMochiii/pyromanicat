using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreenLose : MonoBehaviour
{
    [SerializeField] public TMP_Text totalScore; //in game controller script call gameoverscreen setup with score input

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        totalScore.text = score.ToString() + "points";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
}

