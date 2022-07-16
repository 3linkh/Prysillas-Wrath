using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    Timer timer;

    private void Awake()
    {
          timer = FindObjectOfType<Timer>();
    }
    void Start()
    {
        float timerValue = timer.timerValue;
        float minutes = Mathf.FloorToInt(timerValue / 60);
        float seconds = Mathf.FloorToInt(timerValue % 60);
        float milliseconds = Mathf.FloorToInt((timerValue % 1) *100);
        
        scoreText.text = "Time Alive: " +minutes.ToString() +":"
        + seconds.ToString() + ":" + milliseconds.ToString();
    }
    
}
