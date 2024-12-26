using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyBehaviour : MonoBehaviour
{
    private Vector2 _startDirection;
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _gridSize = 1f;
    

    private void Start()
    {
        Vector2[] directions = {Vector2.down, Vector2.up, Vector2.left, Vector2.right,};
        _startDirection = directions[Random.Range(0, directions.Length)];
        transform.position = SnapToGrid(transform.position);
        Debug.Log(_startDirection);
    }

    private void Update()
    {
        transform.Translate(_startDirection * _moveSpeed * Time.deltaTime);
    }
    
    private Vector2 SnapToGrid(Vector2 position)
    {
        // Привязываем к центру ячейки
        float snappedX = Mathf.Floor(position.x / _gridSize) * _gridSize + _gridSize / 2;
        float snappedY = Mathf.Floor(position.y / _gridSize) * _gridSize + _gridSize / 2;

        return new Vector2(snappedX, snappedY);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacles"))
        {
            Debug.Log("obstacles");
            Vector2[] directions = {Vector2.down, Vector2.up, Vector2.left, Vector2.right,};
            _startDirection = directions[Random.Range(0, directions.Length)];
        }
    }
}
