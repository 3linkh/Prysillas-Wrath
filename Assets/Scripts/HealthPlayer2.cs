using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer2 : MonoBehaviour
{
    [SerializeField] int hitPoints = 3;
    [SerializeField] int damageAmount = 1;
    [SerializeField] ParticleSystem healParticleSystem;
    [SerializeField] AudioSource healAudioSource;

    Animator animator;
    bool playerIsDead = false;

    void Start() 
    {
        animator = GetComponentInChildren<Animator>();
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(damageAmount);
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
