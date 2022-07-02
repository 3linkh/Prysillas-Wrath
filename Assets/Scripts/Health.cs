using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int hitPoints = 3;
    
    
    void KillPlayer()
    {
        if(hitPoints < 0)
        {
            //PlayerDies();
        }
    }

    void PlayerDies()
    {
        //should we use one mover script for each player and tag players? Only want to disable dead player script.
        gameObject.GetComponent<MovePlayer1>().enabled = false; // freeze controls
        
        // death animation
        // death sfx
    }


}
