using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    
    [SerializeField] int damageAmount;

    void OnCollisionEnter(Collision other)
    {
       DealDamage(other.gameObject);    
    }

    void DealDamage(GameObject other)
    {
        gameObject.GetComponent<Health>();
        
    }
    
}
