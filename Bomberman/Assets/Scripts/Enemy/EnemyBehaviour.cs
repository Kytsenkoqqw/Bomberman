using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyBehaviour : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private Transform _target;
    

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (_target == null )
        {
            Debug.Log("Target is null");
        }
        else
        {
            _agent.SetDestination(_target.position);
        }
        
        
    }
}
