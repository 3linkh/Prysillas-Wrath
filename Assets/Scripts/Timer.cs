using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // bug is that timer bounces back and forth
    public float timerValue;
    public bool increaseTime = true;

    //TMP_Text timeText;
    void Start()
    {
        //timeText = GetComponent<TMP_Text>();
        //timeText.text = "Time Alive: " + timerValue.ToString();
                
    }

    void Update()
    {
        //UpdateTimer();
    }

    public void UpdateTimer()
    {
        if (increaseTime == true)
        {
            timerValue += Time.deltaTime;
        }
                     
    }
    public void StopTimer()
    {
        increaseTime = false;
        Debug.Log("Time Stopped");
        
    }

    public void StartTimer()
    {
        increaseTime = true;
        Debug.Log("Start Time");
    }

}
