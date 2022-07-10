using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPBoardP1 : MonoBehaviour
{
    TMP_Text player1HPText;
   
    void Start()
    {

        player1HPText = GetComponent<TMP_Text>();
        Player1HPUpdate(3); // how do I get this to start as the player's set hitpoint value?
       
    }

    public void Player1HPUpdate(int player1HP)
    {
        player1HPText.text = "Player 1 Hit Points: " + player1HP.ToString();
    }
    
}
