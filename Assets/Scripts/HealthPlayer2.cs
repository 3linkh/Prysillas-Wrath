using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthPlayer2 : MonoBehaviour
{
    [SerializeField] int hitPoints = 3;
    [SerializeField] int damageAmount = 1;
    [SerializeField] ParticleSystem healParticleSystem;
    [SerializeField] AudioSource healAudioSource;
    [SerializeField] float forceSpeed = 30f;

    Rigidbody myRigidbody;

    Animator animator;
    bool playerIsDead = false;

    void Start() 
    {
        animator = GetComponentInChildren<Animator>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(damageAmount);
            
            Rigidbody enemyRigidBody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 direction = myRigidbody.transform.position - enemyRigidBody.transform.position;
            myRigidbody.AddForce(direction.normalized * forceSpeed, ForceMode.Impulse);
            
        }
         
    }    
    
    
    void TakeDamage(int damageAmount)
    {
        hitPoints -= damageAmount;

        if(hitPoints <= 0)
        {
            Debug.Log("player dies");
            PlayerDies();
        }
    }
    
    void PlayerDies()
    {
        gameObject.GetComponent<MovePlayer2>().enabled = false; 
        
        playerIsDead = true;
        StartDeathFX();
        
                      
        //gameObject.GetComponent<SphereCollider>().isTrigger = true;
        
        // death animation
        // death sfx
    }

    void StartDeathFX()
    {
        if (playerIsDead == true)
        {
            animator.SetBool("isDying", true);
            animator.SetBool("isMoving", false);
        }
        
    }

    

    void OnTriggerEnter(Collider other)
    {
        if (playerIsDead && other.gameObject.tag == "Player")
        {
            StartCoroutine("Healing");
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        StopCoroutine("Healing");    
    }
    IEnumerator Healing()
    {
        StartHealingAnimation();
        yield return new WaitForSeconds(3f);
        StopHealingAnimation();
        HealPlayer();
        
    }

    void StartHealingAnimation()
    {
        healParticleSystem.Play();
        healAudioSource.Play();

    }

    void StopHealingAnimation()
    {
        healParticleSystem.Stop();
        healAudioSource.Stop();
    }

    void HealPlayer()
    {
        hitPoints = 3;
        gameObject.GetComponent<MovePlayer2>().enabled = true; 
        //gameObject.GetComponent<SphereCollider>().isTrigger = false;
        playerIsDead = false;
        animator.SetBool("isDying", false);
    }


}
