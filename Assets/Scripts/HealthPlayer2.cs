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
    [SerializeField] P2HealingTimer p2healingTimer;
    public bool playerTwoIsDead = false;

    void Start() 
    {
        animator = GetComponentInChildren<Animator>();
        myRigidbody = GetComponent<Rigidbody>();
        hPBoardP2 = FindObjectOfType<HPBoardP2>();
        hPBoardP2.Player2HPUpdate(hitPoints);
        timer = FindObjectOfType<Timer>();
        p2healingTimer = FindObjectOfType<P2HealingTimer>();
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
        if (!playerTwoIsDead)
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
        playerTwoIsDead = true;
        StartDeathFX();
            
        //gameObject.GetComponent<SphereCollider>().isTrigger = true;
        
        // death animation
        // death sfx
        timer.StopTimer();
    }

    void StartDeathFX()
    {
        if (playerTwoIsDead == true)
        {
            animator.SetBool("isDying", true);
            animator.SetBool("isMoving", false);
            timer.StopTimer();
        }
        
    }

    

    void OnTriggerEnter(Collider other)
    {
        if (playerTwoIsDead && other.gameObject.tag == "Player")
        {
            StartCoroutine("Healing");
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        StopCoroutine("Healing");  
        if(playerTwoIsDead)
        {
            p2healingTimer.ResetTimer();
        }  
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

        p2healingTimer.gameTime = 3f;
        p2healingTimer.stopTimer = false;

    }

    void StopHealingAnimation()
    {
        healParticleSystem.Stop();
        healAudioSource.Stop();
    }

    void HealPlayer()
    {
        if(playerTwoIsDead)
        {
        hitPoints += healAmount;
        hPBoardP2.Player2HPUpdate(hitPoints);
        }
        gameObject.GetComponent<MovePlayer2>().enabled = true; 
        playerTwoIsDead = false;
        animator.SetBool("isDying", false);
        timer.StartTimer();
    }


}
