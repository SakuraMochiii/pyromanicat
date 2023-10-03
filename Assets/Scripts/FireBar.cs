using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class FireBar : MonoBehaviour
{
    private float minHeight, maxHeight, currHeight, t;
    public SpawnManager spawnManager;
    public RectTransform rectTransform;

    public TMP_Text scoreText;
    
    

    //private GameOverScreen gameOverWin;
    //private GameOverScreenLose gameOverLose;

    private void GameOverWin()
    {
        SceneManager.LoadScene("End_Win");
        //gameOverWin.Setup(spawnManager.score);
    }

    private void GameOverLose()
    {
        SceneManager.LoadScene("End_Lose");
        //gameOverLose.Setup(spawnManager.score);
    }

    // Start is called before the first frame update
    void Start()
    {
        //scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TMP_Text>();
        //spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        rectTransform = GetComponent<RectTransform>();
        minHeight = rectTransform.offsetMin.y;
        maxHeight = rectTransform.offsetMax.y;
        currHeight = 0;
        t = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        t += ((spawnManager.fireCount + 0.0f) / spawnManager.totalObjects - 0.33f) * Time.deltaTime * 0.2f;
        if (spawnManager.score > spawnManager.winValue) {
            GameOverWin();
        }
        scoreText.text = "Fire Extinguished: " + ((int) ((0.0f + spawnManager.score) / spawnManager.winValue * 100f)) +"%";
        
        if (t < 0) t = 0;
        if (t > 1)
        {
            GameOverLose();
        }
        currHeight = minHeight + (maxHeight - minHeight) * t;
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, currHeight) ;

    }
}
