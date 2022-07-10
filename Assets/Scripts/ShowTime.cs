using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowTime : MonoBehaviour
{
    [SerializeField] Timer timer;

    TMP_Text timeText;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        timeText = GetComponent<TMP_Text>();
        timeText.text = "Time Alive: " + timer.timerValue.ToString();
        
    }
  

    void Update()
    {
        timer.UpdateTimer();
        float timerValue = timer.timerValue;
        float minutes = Mathf.FloorToInt(timerValue / 60);
        float seconds = Mathf.FloorToInt(timerValue % 60);
        float milliseconds = Mathf.FloorToInt((timerValue % 1) *100);
        timeText.text = "Time Alive: " +minutes.ToString() +":"
        + seconds.ToString() + ":" + milliseconds.ToString();
    }
}
