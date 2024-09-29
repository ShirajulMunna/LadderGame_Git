using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Pen : MonoBehaviour
{
    public static Pen Instance { get; private set; }
    public int selectedNumber;
    public WayPoints wayPoint;
    public float speed = 50f;

    public Transform target;
    public int wavePointIndex = 0;
    
    public GameObject[] particlePrefabs;
    public Image[] giftBoxes;
    public Image giftItems;
    public Sprite[] items;
    

    public GameObject blackImgage;

    public GameObject[] particles;
    public int paricleValue;


    private void Start()
    {
       Instance = this;
       target = wayPoint.points[0];
       speed = GameController.instance.speed;
       paricleValue = PlayerPrefs.GetInt("Particle", 0);


    }




    private void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

      
        if (Vector2.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextPoint();
            Debug.Log("Reached");
        }
       
    }

    public void GetNextPoint()
    {
        if (wavePointIndex >= wayPoint.points.Length - 1)
        {
            Debug.Log("Fucking End");

            Debug.Log(selectedNumber);

            giftBoxes[selectedNumber].GetComponent<RectTransform>().DOShakePosition(2f, 10f, 10, 90, true).OnComplete(() => {

                giftBoxes[selectedNumber].GetComponent<RectTransform>().DOMove(new Vector2(0, 0), 0.6f).SetEase(Ease.Flash).OnComplete(() =>
                {
                    AudioManager.Instance.PlayLastPageSound();
                    ActivateParticles();
                    giftBoxes[selectedNumber].gameObject.SetActive(false);
                    blackImgage.SetActive(true);
                    giftItems.gameObject.SetActive(true);
                    giftItems.GetComponent<Image>().sprite = items[Random.Range(0, items.Length)];

                });

            });

            Destroy(gameObject);
            return;
        }

        wavePointIndex++;
        target = wayPoint.points[wavePointIndex];
    }

    public void ActivateParticles()
    {
        if (paricleValue == 0)
        {
            particles[0].SetActive(true);

        }
        else
        {
            particles[1].SetActive(true);

        }

    }

    public void SetparticleValue(int value)
    {
        this.paricleValue = value;


    }




}
