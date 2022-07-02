using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer2 : MonoBehaviour
{
    [SerializeField] float playerMoveSpeed = 10f;

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float moveValue = playerMoveSpeed * Time.deltaTime;
                        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-moveValue,0,0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveValue,0,0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0,0,moveValue);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0,0,-moveValue);
        }

    }
}
