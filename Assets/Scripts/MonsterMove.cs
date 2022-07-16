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
  public bool MonsterActive = true;
  public bool moveSpeedBoost = true;

  NavMeshAgent myMonsterNavMeshAgent;

  [SerializeField] float speedBoostMultiplier;

  // Start is called before the first frame update  
  void Start()
  {
    myMonsterNavMeshAgent = GetComponent<NavMeshAgent>();
    if (players.Length == 0)
    {
      players = GameObject.FindGameObjectsWithTag("Player");
      Debug.Log(players.Length);
    }
    MonsterActive = true;

  }

  // Update is called once per frame
  void Update()
  {
    BoostAccelerationGradual();
    // if (Input.GetKeyDown(KeyCode.M))
    // {
    //   MonsterActive = !MonsterActive;
    // }

    if (MonsterActive)
    {
      if (MonsterMovingState == MonsterMovingStates.stopped || MonsterMovingState == MonsterMovingStates.moving)
      {
        Move();
      }
    }
    UpdateAnimator();
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
      if (!player.GetComponent<HealthStatus>().playerIsAlive)
      {
        curDistance = Mathf.Infinity;
      }
      

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
  void UpdateAnimator()
  {
    Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
    Vector3 localVelocity = transform.InverseTransformDirection(velocity);
    float speed = localVelocity.z;
    GetComponentInChildren<Animator>().SetFloat("forwardSpeed", speed);

  }
  void BoostAccelerationGradual()
  {
    if (moveSpeedBoost)
    {
      myMonsterNavMeshAgent.acceleration += Time.deltaTime * speedBoostMultiplier;
    }
  }
}
