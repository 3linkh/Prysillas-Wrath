using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2HealingTimer : MonoBehaviour
{
    public Slider P2healthSlider;
    public float gameTime;

    public bool stopTimer;
    void Start()
    {
        stopTimer = false;
        P2healthSlider.maxValue = gameTime;
        P2healthSlider.value = gameTime;
    }

    public void Update()
    {
        if (stopTimer == false)
        {
            UpdateHealthTimer();
        }
        else
        {
            return;
        }
        
    }

    public void UpdateHealthTimer()
    {
        gameTime -= Time.deltaTime;
           

        if ( gameTime <= 0)
        {
            stopTimer = true;
        }       

        if (stopTimer == false)
        {
            P2healthSlider.value = gameTime;
        }
    }

    public void ResetTimer()
    {
        stopTimer = true;
        gameTime = 0;
        P2healthSlider.value = gameTime;
    }
}
