using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public event EventHandler onTimeFinished;
    public float totalTime = 10f; // Total time for the countdown
    [SerializeField] private Image sliderImage; // Image used as a slider
    
    public TextMeshProUGUI timerTxt;
    

    void Start()
    {
        StartCoroutine(StartCountdown());

    }
    public void SetTime(int time)
    {
        this.totalTime = time;
       


    }


 

    private IEnumerator StartCountdown()
    {
        float remainingTime = totalTime;

        while (remainingTime > 0)
        {
            // Decrease the remaining time
            remainingTime -= Time.deltaTime;
            int round = (int)MathF.Round(remainingTime);
            timerTxt.text = round.ToString();

            // Update the slider's fill amount
            float fillAmount = remainingTime / totalTime;
            sliderImage.fillAmount = fillAmount;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the slider is completely empty when the time is up
        sliderImage.fillAmount = 0;

        // Code to execute when the countdown ends
        TimerEnded();
    }

    private void TimerEnded()
    {
        Debug.Log("Countdown finished!");
        // Add additional logic for when the timer ends, if needed

        GameController.instance.DisableButtons();
        
    }
}
