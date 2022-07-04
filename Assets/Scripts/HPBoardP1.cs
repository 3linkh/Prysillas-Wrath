using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPBoardP1 : MonoBehaviour
{
    int player1HP;

    TMP_Text player1HPText;
        
    void Start()
    {
        player1HPText = GetComponent<TMP_Text>();
        player1HPText.text = "Player 1 Hit Points: " + player1HP.ToString();
    }

    public void Player1HPUpdate(int player1HPUpdate)
    {
        player1HP += player1HPUpdate;
        player1HPText.text = "Player 1 Hit Points: " + player1HP.ToString();
    }
    
}
