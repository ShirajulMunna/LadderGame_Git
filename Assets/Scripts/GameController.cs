using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public EventChannel startGame;
    public GameObject[] ladders;
    public GameObject[] l_wayPoints;
    public GameObject[] selectedItems;
    public GameObject[] pens;
    public int randomNumber;
    public GameObject adminPanel;
    public bool isGameOn;


    [SerializeField]  private List<GameObject> frontObjects = new List<GameObject>();

    void Start()
    {
        instance = this;
        randomNumber = Random.Range(0, ladders.Length);

       



    }

    private void OnEnable()
    {
        startGame.OnEventRaise += LadderSelection;
      
    }

    private void OnDisable()
    {
        startGame.OnEventRaise -= LadderSelection;


    }


    private void OnButtonClick(Button clickedButton)
    {
       
        foreach (GameObject obj in frontObjects)
        {
            Button button = obj.GetComponent<Button>();

            if (button != null)
            {
                
                if (button == clickedButton)
                {
                    button.interactable = true;
                }
                else
                {
                    button.interactable = false;
                }
            }
        }
    }

    public void DisableButtons() 
    {
        foreach (GameObject obj in frontObjects)
        {
            Button button = obj.GetComponent<Button>();
           
            button.interactable = false;
                          
        }

    }


    public void LadderSelection() 
    {
       
        selectedItems[randomNumber].SetActive(true);
        ladders[randomNumber].SetActive(true);
        l_wayPoints[randomNumber].SetActive(true);
        pens[randomNumber].SetActive(true);

        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == "Front")
            {
                frontObjects.Add(obj);


                Button button = obj.GetComponent<Button>();
                if (button != null)
                {
                    button.onClick.AddListener(() => OnButtonClick(button));
                }
            }
        }


    }

    public void Update()
    {
        if (!isGameOn)
        {

            if (Input.GetKeyDown(KeyCode.F12))
            {
                adminPanel.SetActive(true);

            }

        }
    }

}
