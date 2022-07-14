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
        scoreText.text = "Time Alive: " + timer.timerValue;
    }
    
}
