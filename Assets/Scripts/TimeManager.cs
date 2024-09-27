using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;
    public event EventHandler onTimeFinished;
    public float totalTime = 10f; // Total time for the countdown
    [SerializeField] private Image sliderImage; // Image used as a slider
    
    public TextMeshProUGUI timerTxt;
    public bool isTimeStarted;
    public float fillAmount;


    private void Start()
    {
        Instance = this;
    }
    public void StartTime() 
    {
       
        StartCoroutine(StartCountdown());
      
    }
    public void SetTime(int time)
    {
        this.totalTime = time;
      
    }

    private void Update()
    {
        if (isTimeStarted) 
        {
            sliderImage.fillAmount = fillAmount;

        }
    }




    private IEnumerator StartCountdown()
    {
        float remainingTime = totalTime;

        while (remainingTime > 0 && !isTimeStarted)
        {
            // Decrease the remaining time
            remainingTime -= Time.deltaTime;
            int round = (int)MathF.Round(remainingTime);
            timerTxt.text = round.ToString();

            // Update the slider's fill amount
             fillAmount = remainingTime / totalTime;
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
        
        // Add additional logic for when the timer ends, if needed

        GameController.instance.DisableButtons();
        
    }
}
