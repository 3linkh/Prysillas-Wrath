using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthPlayer1 : MonoBehaviour
{
    public int hitPoints = 3;
    [SerializeField] int damageAmount = 1;
    [SerializeField] int healAmount = 3;
    [SerializeField] ParticleSystem healParticleSystem;
    [SerializeField] AudioSource healAudioSource;
    [SerializeField] float forceSpeed = 30f;

    Rigidbody myRigidbody;
    HPBoardP1 hPBoardP1;

    Animator animator;
    [SerializeField] Timer timer;
    bool playerIsDead = false;
    
    void Start()
    {
        
        animator = GetComponentInChildren<Animator>();
        myRigidbody = GetComponent<Rigidbody>();
        hPBoardP1 = FindObjectOfType<HPBoardP1>();
        hPBoardP1.Player1HPUpdate(hitPoints);
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

    public void TakeDamage()
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
        hPBoardP1.Player1HPUpdate(hitPoints); 
        
    }

    public void PlayerDies()
    {
        gameObject.GetComponent<MovePlayer1>().enabled = false; 
        playerIsDead = true;
        StartDeathFX();
             
        
        // death sfx
        
                
    }

    void StartDeathFX()
    {
        if (playerIsDead == true)
        {
            animator.SetBool("isDying", true);
            animator.SetBool("isMoving", false);
            timer.StopTimer();
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

    public void HealPlayer()
    {
        if(playerIsDead)
        {
            hitPoints += healAmount;
            hPBoardP1.Player1HPUpdate(hitPoints);
        }
        gameObject.GetComponent<MovePlayer1>().enabled = true; 
        playerIsDead = false;
        animator.SetBool("isDying", false);
        timer.StartTimer();
    }

    


}
