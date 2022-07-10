using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPBoardP2 : MonoBehaviour
{
    TMP_Text player2HPText;
   
    void Start()
    {

        player2HPText = GetComponent<TMP_Text>();
        Player2HPUpdate(3); // how do I get this to start as the player's set hitpoint value?
       
    }

    public void Player2HPUpdate(int player2HP)
    {
        player2HPText.text = "Player 2 Hit Points: " + player2HP.ToString();
    }
    
}
