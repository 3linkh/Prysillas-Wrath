using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class HealthPlayer1 : MonoBehaviour
{
    public int hitPoints = 3;
    [SerializeField] int damageAmount = 1;
    [SerializeField] int healAmount = 3;
    [SerializeField] float healTime = 2f;
    [SerializeField] ParticleSystem healParticleSystem;
    [SerializeField] AudioSource healAudioSource;
    [SerializeField] float forceSpeed = 30f;
    [SerializeField] HealthPlayer2 healthPlayer2;
    [SerializeField] LevelManager mylevelManager;

    

    Rigidbody myRigidbody;
    HPBoardP1 hPBoardP1;

    Animator animator;
    [SerializeField] Timer timer;
    [SerializeField] HealingTimer healingTimer;
    public bool playerIsDead = false;
    
    void Start()
    {
        
        animator = GetComponentInChildren<Animator>();
        myRigidbody = GetComponent<Rigidbody>();
        hPBoardP1 = FindObjectOfType<HPBoardP1>();
        hPBoardP1.Player1HPUpdate(hitPoints);
        timer = FindObjectOfType<Timer>();
        healingTimer = FindObjectOfType<HealingTimer>();
           

    }
    void Update()
    {
        EndGame();
           
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
        gameObject.GetComponent<HealthStatus>().playerIsAlive = false;
        
             
        
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
        if(playerIsDead)
        {
            healingTimer.ResetTimer();
        }
    }
    IEnumerator Healing()
    {
        StartHealingAnimation();
        yield return new WaitForSeconds(healTime);
        StopHealingAnimation();
        HealPlayer();
        timer.StartTimer();
        
        
    }

    void StartHealingAnimation()
    {
        healParticleSystem.Play();
        healAudioSource.Play();
        
        healingTimer.gameTime = healTime;
        healingTimer.stopTimer = false;

    }

    void StopHealingAnimation()
    {
        healParticleSystem.Stop();
        healAudioSource.Stop();
         //- this might break it
        
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
        gameObject.GetComponent<HealthStatus>().playerIsAlive = true;
        animator.SetBool("isDying", false);
        timer.StartTimer();
    }

    public void EndGame()
    {
        Debug.Log(playerIsDead +" " + healthPlayer2.playerTwoIsDead);
        
        if (playerIsDead && healthPlayer2.playerTwoIsDead)
        {
            mylevelManager.Invoke("LoadGameOver", 1f);
        }
    }

    


}
