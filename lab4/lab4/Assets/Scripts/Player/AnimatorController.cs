using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent navMeshAgent;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("magnitude", navMeshAgent.velocity.magnitude);
    }
}
