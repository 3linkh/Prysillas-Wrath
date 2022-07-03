using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{

  public GameObject[] players;
  private enum MonsterMovingStates
  {
    stopped,
    moving,
    charging,
    stunned
  }
  private MonsterMovingStates MonsterMovingState = MonsterMovingStates.stopped;
  public bool MonsterActive = false;

  // Start is called before the first frame update  
  void Start()
  {
    if (players.Length == 0)
    {
      players = GameObject.FindGameObjectsWithTag("Player");
      Debug.Log(players.Length);
    }



  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.M))
    {
      MonsterActive = !MonsterActive;
    }

    if (MonsterActive)
    {
      if (MonsterMovingState == MonsterMovingStates.stopped || MonsterMovingState == MonsterMovingStates.moving)
      {
        Move();
      }
    }
  }

  void Move()
  {
    GameObject closestPlayer = players[0];
    float closestDistance = Mathf.Infinity;

    foreach (GameObject player in players)
    {
      Vector3 diff = player.transform.position - transform.position;
      float curDistance = diff.sqrMagnitude;
      Debug.Log(curDistance);

      if (curDistance < closestDistance)
      {
        closestDistance = curDistance;
        closestPlayer = player;
      }
    }

    NavMeshAgent agent = GetComponent<NavMeshAgent>();
    agent.destination = closestPlayer.transform.position;
    MonsterMovingState = MonsterMovingStates.moving;
  }
}
