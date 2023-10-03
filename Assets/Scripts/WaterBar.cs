using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class WaterBar : MonoBehaviour
{
    private float minHeight, maxHeight, currHeight, t;
    public CursorManager cursorManager;
    public RectTransform rectTransform;

    public TMP_Text scoreText;


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
        t = cursorManager.waterLevel / cursorManager.maxWater;
        
        
        if (t < 0) t = 0;
        if (t > 1)
        {
            t = 1;
        }
        currHeight = minHeight + (maxHeight - minHeight) * t;
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, currHeight);

    }
}