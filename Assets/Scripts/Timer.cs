using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // bug is that timer bounces back and forth
    float timerValue;

    TMP_Text timeText;
    void Start()
    {
        timeText = GetComponent<TMP_Text>();
        timeText.text = "Time Alive: " + timerValue.ToString();
    }

    void Update()
    {
        UpdateTimer();
    }

    public void UpdateTimer()
    {
        timerValue += Time.deltaTime;
        float minutes = Mathf.FloorToInt(timerValue / 60);
        float seconds = Mathf.FloorToInt(timerValue % 60);
        float milliseconds = Mathf.FloorToInt((timerValue % 1) *100);
        timeText.text = "Time Alive: " +minutes.ToString() +":"
        + seconds.ToString() + ":" + milliseconds.ToString();
        
        
        
    }
}
