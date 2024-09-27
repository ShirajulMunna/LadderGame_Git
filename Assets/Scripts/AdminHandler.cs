using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminHandler : MonoBehaviour
{
    public static AdminHandler Instance;
    public Slider[] adminSliders;
    private int  time,penSpeed,particles;
    void Start()
    {
        Instance = this;

       
        
    }

    private void OnEnable()
    {
        time = PlayerPrefs.GetInt("Time", 5);
        penSpeed = PlayerPrefs.GetInt("PenSpeed", 5);
        particles = PlayerPrefs.GetInt("Particle", 0);

        UpdateTimeSlider();
        UpdatePenSpeedSlider();
        UpdateParticleSlider();

    }

    public void UpdateTimeSlider() 
    {
        if (time == 5)
        {
            adminSliders[1].value = 1;

        }
        else if (time == 7)
        {
            adminSliders[1].value = 2;

        }
        else
        {
            adminSliders[1].value = 3;

        }

    }

    public void UpdatePenSpeedSlider() 
    {
        if (penSpeed == 2)
        {
            adminSliders[0].value = 1;

        }
        else if (penSpeed == 3)
        {
            adminSliders[0].value = 2;

        }
        else
        {
            adminSliders[0].value = 3;

        }

    }

    public void UpdateParticleSlider() 
    {
        if (particles == 0)
        {
            adminSliders[2].value = 1;

        }
        else if (particles == 1)
        {
            adminSliders[2].value = 3;

        }

    }



    
   
}
