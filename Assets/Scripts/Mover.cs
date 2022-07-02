using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(xMove, 0f, zMove);

        transform.Translate(movement * moveSpeed *Time.deltaTime, Space.World);
    }

}
