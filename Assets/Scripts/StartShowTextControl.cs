using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartShowTextControl : MonoBehaviour
{
    //private int StartTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Countdown()
    {
        gameObject.SetActive(true);
        //InvokeRepeating("ShowStartText", 0.0f, 1.0f);
        Invoke("ShowStartText", 5.0f);
    }

    private void ShowStartText()
    {
        //if (StartTime > 0)
        //{
        //    transform.GetComponent<Text>().text = "" + StartTime;
        //}
        //else
        //{
        //    transform.GetComponent<Text>().text = "GO ! ! !";
        //}
        //if (StartTime == -1)
        //{
        //    CancelInvoke("ShowStartText");
        //    gameObject.SetActive(false);
        //}
        //StartTime--;
        gameObject.SetActive(false);
    }
}
