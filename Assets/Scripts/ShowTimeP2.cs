using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowTimeP2 : MonoBehaviour
{
    [SerializeField] Timer timer;

    TMP_Text timeTextP2;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        timeTextP2 = GetComponent<TMP_Text>();
        timeTextP2.text = "Time Alive: " + timer.timerValue.ToString();
        
    }
  

    void Update()
    {
        timer.UpdateTimer();
        float timerValue = timer.timerValue;
        float minutes = Mathf.FloorToInt(timerValue / 60);
        float seconds = Mathf.FloorToInt(timerValue % 60);
        float milliseconds = Mathf.FloorToInt((timerValue % 1) *100);
        timeTextP2.text = "Time Alive: " +minutes.ToString() +":"
        + seconds.ToString() + ":" + milliseconds.ToString();
    }
}
