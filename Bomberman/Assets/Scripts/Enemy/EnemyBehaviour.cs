using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float _wanderRadius = 10f; // Радиус, в котором будут генерироваться точки
    [SerializeField] private float _waitTime = 2f;      // Время ожидания перед движением к новой точке
    private NavMeshAgent _agent;
    private float _timer;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        MoveToRandomPoint();
        _agent.updateUpAxis = false;
        _agent.updateRotation = false;
    }

    private void Update()
    {
        // Проверяем, достиг ли агент текущей цели
        if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
        {
            _timer += Time.deltaTime;
            if (_timer >= _waitTime)
            {
                MoveToRandomPoint();
                _timer = 0f;
            }
        }
    }

    private void MoveToRandomPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * _wanderRadius; // Генерация случайного направления
        randomDirection += transform.position; // Смещение в локальные координаты

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, _wanderRadius, NavMesh.AllAreas))
        {
            hit.position = new Vector2(Mathf.Floor(hit.position.x) + 0.5f, Mathf.Floor(hit.position.y) + 0.5f);
            _agent.SetDestination(hit.position); // Устанавлив
        }
    }
}
