using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Dictionary<string, Vector3> teleports = new Dictionary<string, Vector3>();

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        teleports.Add("Teleport1", new Vector3(-216, 0, -6));
        teleports.Add("Teleport2", new Vector3(30, 0, 5));
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (teleports.ContainsKey(other.tag))
                navMeshAgent.Warp(teleports.GetValueOrDefault(other.tag));
        }
    }
}
