using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealingTimer : MonoBehaviour
{
    public Slider healthSlider;
    public float gameTime;

    public bool stopTimer;
    void Start()
    {
        stopTimer = false;
        
        healthSlider.maxValue = gameTime;
        healthSlider.value = gameTime;
        
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
            healthSlider.value = gameTime;
        }
    }

    public void ResetTimer()
    {
        stopTimer = true;
        gameTime = 0;
        healthSlider.value = gameTime;
    }
}
