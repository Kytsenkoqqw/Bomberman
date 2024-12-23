using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;
    private Vector2 _startDirection;
    
    private void Start()
    {
        // Задаём начальное случайное направление
        Vector2[] directions = { Vector2.down, Vector2.left, Vector2.right, Vector2.up };
        _startDirection = directions[Random.Range(0, directions.Length)];
    }

    private void Update()
    {
        // Двигаем объект в выбранном направлении
        transform.Translate(_startDirection * _moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Проверка на столкновение с объектами на слоях "obstacles" или "interactable"
        if (other.gameObject.CompareTag("interactable") || other.gameObject.CompareTag("Obstacles"))
        {
            Debug.Log("Enemy bam");

            // Задаём новое случайное направление, исключая текущее
            Vector2[] directions = { Vector2.down, Vector2.left, Vector2.right, Vector2.up };
            Vector2 newDirection;

            // Повторяем выбор, пока не получим направление, отличное от текущего
            do
            {
                newDirection = directions[Random.Range(0, directions.Length)];
            } while (newDirection == _startDirection); // Проверка, что новое направление не совпадает с текущим

            // Обновляем направление
            _startDirection = newDirection;
        }
    }
}
