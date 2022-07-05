using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer1 : MonoBehaviour
{
    [SerializeField] int hitPoints = 3;
    [SerializeField] int damageAmount = 1;
    [SerializeField] ParticleSystem healParticleSystem;
    [SerializeField] AudioSource healAudioSource;

    HPBoardP1 hPBoardP1;

    Animator animator;
    bool playerIsDead = false;

    void Start()
    {
        hPBoardP1 = FindObjectOfType<HPBoardP1>();
        animator = GetComponentInChildren<Animator>();

    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage();
        }
         
    }

    public void TakeDamage()
    {
        hitPoints -= damageAmount;
        
        if(hitPoints <= 0)
        {
            Debug.Log("player dies");
            PlayerDies();
        }
        hPBoardP1.Player1HPUpdate(hitPoints); // bug - the values dont reflect what is 
                                                // in the serialized field. if hitPoints -= damageAmount
                                                // is put in, player looses 2 per hit instead of 1 but text is
    }

    

    void PlayerDies()
    {
        gameObject.GetComponent<MovePlayer1>().enabled = false; 
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
        hPBoardP1.Player1HPUpdate(hitPoints);
        gameObject.GetComponent<MovePlayer1>().enabled = true; 
        //gameObject.GetComponent<SphereCollider>().isTrigger = false;
        playerIsDead = false;
        animator.SetBool("isDying", false);
    }


}
