using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeadPlayer2Alert : MonoBehaviour
{
    [SerializeField] HealthPlayer2 healthPlayer2;
    [SerializeField] TextMeshProUGUI dead2PlayerAlertText;
    [SerializeField] float messageDurationTime = 3f;

    bool hasShowedAlertText = false;
    

    private void Awake()
    {
          healthPlayer2 = FindObjectOfType<HealthPlayer2>();
    }
    void Start()
    {
        dead2PlayerAlertText.text = "";
    }
        
    void Update()
    {
        if (healthPlayer2.playerTwoIsDead == false)
        {
            hasShowedAlertText = false;
        }
        if(healthPlayer2.playerTwoIsDead && hasShowedAlertText == false)
        {
            StartCoroutine("P2HealingAlert");
        }
        
        else
        {
            dead2PlayerAlertText.text = "";
        } 

        
    }
    IEnumerator P2HealingAlert()
    {
           
           dead2PlayerAlertText.text = "Player TWO Needs Healing!";
           yield return new WaitForSeconds(messageDurationTime);
           dead2PlayerAlertText.text = "";
            hasShowedAlertText = true;
                
    }
}
