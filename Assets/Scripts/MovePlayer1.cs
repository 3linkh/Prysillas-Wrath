using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer1 : MonoBehaviour
{
    [SerializeField] float playerMoveSpeed = 10f;
    // [SerializeField] float rotationSpeed = 10f;
    
    private Animator animator;
    Rigidbody myRigidBody;
    
    

    void Update()
    {
        animator = GetComponentInChildren<Animator>();
        myRigidBody = GetComponent<Rigidbody>();
        
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
                        
        if (Input.GetKey(KeyCode.A))
        {            
            transform.Translate(moveLeft, Space.World);
            if (moveLeft != Vector3.zero)
            {
                animator.SetBool("isMoving", true);
                transform.forward = moveLeft;
            }
            
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveRight, Space.World);
            if (moveRight != Vector3.zero)
            {
                animator.SetBool("isMoving", true);
                transform.forward= moveRight;
            }
            
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(moveUp, Space.World);
            if (moveUp != Vector3.zero)
            {
                animator.SetBool("isMoving", true);
                transform.forward = moveUp;
            }
            
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(moveDown, Space.World);
            if (moveDown != Vector3.zero)
            {
                animator.SetBool("isMoving", true);
                transform.forward = moveDown;
            }
            
        }
        
               
        //For smoother turns possibly
        // Quaternion toRotation = Quaternion.LookRotation(moveLeft, Vector3.up);
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

    }

}
