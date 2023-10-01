using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RefillQuestion : MonoBehaviour
{
    private TMP_Text number1Txt, number2Txt, operationTxt;
    private TMP_InputField input;
    private int n1, n2, answer;
    private Image backgroundImg;

    private CursorManager cursorManager;
    
    // Start is called before the first frame update
    void Start()
    {
        number1Txt = GameObject.FindGameObjectWithTag("Number1").GetComponent<TMP_Text>();
        number2Txt = GameObject.FindGameObjectWithTag("Number2").GetComponent<TMP_Text>();
        operationTxt = GameObject.FindGameObjectWithTag("Operation").GetComponent<TMP_Text>();
        input = GameObject.FindGameObjectWithTag("InputField").GetComponent<TMP_InputField>();
        backgroundImg = GetComponent<Image>();

        cursorManager = GameObject.FindGameObjectWithTag("Cursor").GetComponent<CursorManager>();
        
        randomAddition();
    }
    private void Update()
    {
        input.Select();
    }


    void randomAddition()
    {
        n1 = Random.Range(100, 1000);
        n2 = Random.Range(100, 1000);
        answer = n1 + n2;
        operationTxt.text = "+";
        number1Txt.text = n1.ToString();
        number2Txt.text = n2.ToString();
    }
    void randomMultiplication()
    {
        n1 = Random.Range(3, 15);
        n2 = Random.Range(3, 15);
        answer = n1 * n2;
        operationTxt.text = "x";
        number1Txt.text = n1.ToString();
        number2Txt.text = n2.ToString();
    }

    public void checkAnswer()
    {
        if (input.text == answer.ToString())
        {
            input.text = "";
            randomAddition();
            StartCoroutine(flashColor(Color.green));
            cursorManager.refillWater();
        }
        else 
        {
            //randomAddition();
            //StartCoroutine(flashColor(Color.red));
        }
    }
    IEnumerator flashColor(Color c)
    {
        Color original = backgroundImg.color;
        for (float t = 0; t < 1.0f; t += 0.01f)
        {
            backgroundImg.color = Color.Lerp(c, original, t);
            yield return null;
        }
        backgroundImg.color = original;
    }

}
