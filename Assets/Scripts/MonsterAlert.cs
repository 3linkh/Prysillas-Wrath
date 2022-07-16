using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonsterAlert : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI p1monsterTextAlert;
    [SerializeField] TextMeshProUGUI p2monsterTextAlert;
    
    [SerializeField] float messageDurationTime = 3f;

    public float myTime = 0f;

    bool hasShowedMonsterAlertText = false;
        
    void Start()
    {
        
    }
        
    void Update()
    {
        
        if (hasShowedMonsterAlertText == false)
        {
            StartCoroutine("MonsterTextAlert");  
        }
          
    }

    IEnumerator MonsterTextAlert()
    {   
        p1monsterTextAlert.text = "";
        p2monsterTextAlert.text = "";
        yield return new WaitForSeconds(1.5f);
        p1monsterTextAlert.text = "Prysilla is Coming. Stay Alive!";
        p2monsterTextAlert.text = "Prysilla is Coming. Stay Alive!";
        yield return new WaitForSeconds(messageDurationTime);
        p1monsterTextAlert.text = "";
        p2monsterTextAlert.text = "";
        hasShowedMonsterAlertText = true;
    }
                       
    
}
