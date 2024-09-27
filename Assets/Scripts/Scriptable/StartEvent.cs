using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartEvent : MonoBehaviour
{
    public EventChannel startEventSO;
    public Button StartButton;

    // Update is called once per frame
   
    private void Start()
    {
        StartButton.onClick.AddListener(StartGame);
    }

   public void StartGame()
   {
        startEventSO.RaiseEvent();
        GameController.instance.isGameOn = true;
   }



}
