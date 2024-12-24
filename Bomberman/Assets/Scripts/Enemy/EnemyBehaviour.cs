using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private NavMeshAgent agent;

    private void Start()
    {
        agent.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(_target.position);
    }
}
