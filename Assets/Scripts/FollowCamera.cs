using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform followTarget;

    void Update()
    {
        transform.position = followTarget.position;    
    }
}
