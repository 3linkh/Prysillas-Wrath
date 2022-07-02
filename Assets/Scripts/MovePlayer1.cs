using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer1 : MonoBehaviour
{
    [SerializeField] float playerMoveSpeed = 10f;

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float moveValue = playerMoveSpeed * Time.deltaTime;
                        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveValue,0,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveValue,0,0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0,0,moveValue);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0,0,-moveValue);
        }

    }

}
