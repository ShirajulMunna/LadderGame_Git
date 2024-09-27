using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pen : MonoBehaviour
{
    public int selectedNumber;
    public WayPoints wayPoint;
    public float speed = 50f;

    public Transform target;
    public int wavePointIndex = 0;
    public GameObject[] particlePrefabs;
    public Image[] giftBoxes;
    public Image[] giftItems;
   

    private void Start()
    {
       
        target = wayPoint.points[0];
       




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
            giftBoxes[selectedNumber].gameObject.SetActive(false);
            particlePrefabs[selectedNumber].SetActive(true);
            giftItems[selectedNumber].gameObject.SetActive(true);
            Destroy(gameObject);
            return;
        }

        wavePointIndex++;
        target = wayPoint.points[wavePointIndex];
    }

   

   
}
