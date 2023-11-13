using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    public NavMeshAgent ai;
    public Transform player;

    private void Start()
    {
        ai = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        ai.SetDestination(player.position);
    }
}
