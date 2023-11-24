using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Vector3 newPosition;
            switch (other.gameObject.tag)
            {
                case "Teleport1":
                    newPosition = new Vector3(-216, 0, -6);
                    break;
                case "Teleport2":
                    newPosition = new Vector3(30, 0, 5);
                    break;
                default:
                    newPosition = transform.position;
                    break;
            }
            navMeshAgent.Warp(newPosition);
        }
    }
}
