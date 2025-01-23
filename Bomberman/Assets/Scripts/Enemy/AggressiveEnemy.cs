using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AggressiveEnemy : MonoBehaviour
{
   [SerializeField] private Transform _target;
   private NavMeshAgent _agent;

   private void Start()
   {
      _agent = GetComponent<NavMeshAgent>();
      _agent.updateRotation = false;
      _agent.updateUpAxis = false;
   }

   private void Update()
   {
      if (_target == null)
      {
         Debug.Log("targt is null");
      }
      else
      {
         _agent.SetDestination(_target.position);
      }
   }


}
