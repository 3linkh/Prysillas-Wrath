using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeadPlayer1Alert : MonoBehaviour
{
    [SerializeField] HealthPlayer1 healthPlayer1;
    [SerializeField] TextMeshProUGUI deadPlayer1AlertText;
    [SerializeField] float messageDurationTime = 3f;

    bool hasShowedAlertText = false;
    

    private void Awake()
    {
          healthPlayer1 = FindObjectOfType<HealthPlayer1>();
          
    }
    void Start()
    {
        deadPlayer1AlertText.text = "";
    }
        
    void Update()
    {
        if (healthPlayer1.playerIsDead == false)
        {
            hasShowedAlertText = false;
        }
        if(healthPlayer1.playerIsDead && hasShowedAlertText == false)
        {
            StartCoroutine("P1HealingAlert");
        }
        
        else
        {
            deadPlayer1AlertText.text = "";
        } 

        
    }

    IEnumerator P1HealingAlert()
    {     
        deadPlayer1AlertText.text = "Player ONE Needs Healing!";
        yield return new WaitForSeconds(messageDurationTime);
        deadPlayer1AlertText.text = "";
        hasShowedAlertText = true;
    }
                       
    
}
