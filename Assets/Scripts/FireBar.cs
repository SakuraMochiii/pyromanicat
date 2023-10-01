using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBar : MonoBehaviour
{
    private float minHeight, maxHeight, currHeight, t;
    private SpawnManager spawnManager;
    private RectTransform rectTransform;



    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        rectTransform = GetComponent<RectTransform>();
        minHeight = rectTransform.offsetMin.y;
        maxHeight = rectTransform.offsetMax.y;
        currHeight = 0;
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t += ((spawnManager.fireCount + 0.0f)/spawnManager.totalObjects - 0.33f) * Time.deltaTime * 0.2f;
        if (t < 0) t = 0;
        if (t > 1) t = 1;
        currHeight = minHeight + (maxHeight - minHeight) * t;
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, currHeight) ;

    }
}
