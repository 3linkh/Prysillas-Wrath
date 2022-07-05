using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer2 : MonoBehaviour
{
    [SerializeField] float playerMoveSpeed = 10f;

    private Animator animator;

    void Update()
    {
        animator = GetComponentInChildren<Animator>();
        
        animator.SetBool("isMoving", false);
        
        MovePlayer();
    }

    void MovePlayer()
    {
        float moveValue = playerMoveSpeed * Time.deltaTime;
        Vector3 moveLeft = new Vector3(-moveValue,0,0);
        Vector3 moveRight = new Vector3(moveValue,0,0);
        Vector3 moveUp = new Vector3(0,0,moveValue);
        Vector3 moveDown = new Vector3(0,0,-moveValue);
                        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(moveLeft, Space.World);
            if (moveLeft != Vector3.zero)
            {
                animator.SetBool("isMoving", true);
                transform.forward = moveLeft;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveRight, Space.World);
            if (moveRight != Vector3.zero)
            {
                animator.SetBool("isMoving", true);
                transform.forward= moveRight;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(moveUp, Space.World);
            if (moveUp != Vector3.zero)
            {
                animator.SetBool("isMoving", true);
                transform.forward = moveUp;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(moveDown, Space.World);
            if (moveDown != Vector3.zero)
            {
                animator.SetBool("isMoving", true);
                transform.forward = moveDown;
            }
        }

    }
}
