using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthPlayer2 : MonoBehaviour
{
    public int hitPoints = 3;
    [SerializeField] int damageAmount = 1;
    [SerializeField] int healAmount = 3;
    
    [SerializeField] ParticleSystem healParticleSystem;
    [SerializeField] AudioSource healAudioSource;
    [SerializeField] float forceSpeed = 30f;

    Rigidbody myRigidbody;
    HPBoardP2 hPBoardP2;

    Animator animator;

    [SerializeField] Timer timer;
    bool playerIsDead = false;

    void Start() 
    {
        animator = GetComponentInChildren<Animator>();
        myRigidbody = GetComponent<Rigidbody>();
        hPBoardP2 = FindObjectOfType<HPBoardP2>();
        hPBoardP2.Player2HPUpdate(hitPoints);
        timer = FindObjectOfType<Timer>();
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage();
            
            Rigidbody enemyRigidBody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 direction = myRigidbody.transform.position - enemyRigidBody.transform.position;
            myRigidbody.AddForce(direction.normalized * forceSpeed, ForceMode.Impulse);
            
        }
         
    }    
    
    
    void TakeDamage()
    {
        if (!playerIsDead)
        {
            hitPoints -= damageAmount;
        }

        if(hitPoints <= 0)
        {
            Debug.Log("player dies");
            PlayerDies();
        }
        hPBoardP2.Player2HPUpdate(hitPoints);
        
        

    }
    
    void PlayerDies()
    {
        gameObject.GetComponent<MovePlayer2>().enabled = false; 
        playerIsDead = true;
        StartDeathFX();
            
        //gameObject.GetComponent<SphereCollider>().isTrigger = true;
        
        // death animation
        // death sfx
        timer.StopTimer();
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
        timer.StartTimer();
        
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
        if(playerIsDead)
        {
        hitPoints += healAmount;
        hPBoardP2.Player2HPUpdate(hitPoints);
        }
        gameObject.GetComponent<MovePlayer2>().enabled = true; 
        playerIsDead = false;
        animator.SetBool("isDying", false);
        timer.StartTimer();
    }


}
