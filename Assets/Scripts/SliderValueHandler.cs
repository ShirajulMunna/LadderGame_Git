using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SliderValueHandler : MonoBehaviour
{
    public UnityEngine.UI.Slider[] sliders;
    public int speed_1, speed_2, speed_3;
    public int time_1,time_2,time_3;
    
    //hskhskfhk
    void Start()
    {
    

        for (int i = 0; i < sliders.Length; i++) 
        {
            int index = i;
            sliders[i].onValueChanged.AddListener(delegate { OnSliderValueChanged(index); });


        }

    }

    public void OnSliderValueChanged(int sliderindex) 
    {
        Debug.Log(sliderindex);

        switch (sliderindex) 
        {
            case 0:
                Debug.Log("Set time here");

                
                SetTime(sliderindex);

                break;

            case 1:
                Debug.Log("Set penspeed here");
                
                SetPenSpeed(sliderindex);

                break;
            case 2:
                Debug.Log("Set particle here");
                SetParticles(sliderindex);
                break;
            

        }


    }

    public void SetPenSpeed(int index) 
    {
        if (sliders[index].value == 1)
        {
            GameController.instance.SetPenSpeed(speed_1);
            PlayerPrefs.SetInt("PenSpeed", speed_1);


        }
        else if (sliders[index].value == 2)
        {
            
            GameController.instance.SetPenSpeed(speed_2);
            PlayerPrefs.SetInt("PenSpeed", speed_2);



        }
        else 
        {
            
            GameController.instance.SetPenSpeed(speed_3);
            PlayerPrefs.SetInt("PenSpeed", speed_3);


        }

    }

    public void SetTime(int index) 
    {
        if (sliders[index].value == 1)
        {
            TimeManager.Instance.SetTime(time_1);
            PlayerPrefs.SetInt("Time", time_1);


        }
        else if (sliders[index].value == 2)
        {
            TimeManager.Instance.SetTime(time_2);
            PlayerPrefs.SetInt("Time", time_2);


        }
        else 
        {
            TimeManager.Instance.SetTime(time_3);
            PlayerPrefs.SetInt("Time", time_3);


        }

    }

    public void SetParticles(int index) 
    {
        if (sliders[index].value == 1)
        {
            GameController.instance.SetparticleValue(0);
            PlayerPrefs.SetInt("Particle", 0);
        }
        else if (sliders[index].value == 3)
        {
            GameController.instance.SetparticleValue(1);
            PlayerPrefs.SetInt("Particle", 1);

        }
        

    
    }
  
}
