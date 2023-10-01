using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image progressBar; 
    private int firesExtinguished = 0;
    private int totalFires = 100; 

    public void OnFireExtinguished()
    {
        firesExtinguished++; 
        UpdateProgressBar(); 
    }

    
    private void UpdateProgressBar()
    {
        float progress = (float)firesExtinguished / totalFires; //calculate the progress
        progressBar.fillAmount = progress; //update the progress bar fill amount
    }
}