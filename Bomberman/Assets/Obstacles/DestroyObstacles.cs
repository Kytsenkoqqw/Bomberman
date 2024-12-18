using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyObstacles : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;  // Ссылка на Tilemap
    [SerializeField] private Collider2D[] collider2D;  // Ссылка на коллайдер

    void Start()
    {
        // Если на объекте нет компонента Collider2D, то мы пытаемся взять его из сцены.
        if (collider2D == null)
        {
            collider2D = GetComponent<Collider2D[]>();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("DamageArea"))  // Здесь можно использовать любую метку, которая соответствует нужному объекту
        {
            // Преобразуем мировую позицию столкновения в координаты Tilemap
            Vector3Int tilePosition = tilemap.WorldToCell(other.transform.position);

            // Удаляем тайл в этой клетке
            tilemap.SetTile(tilePosition, null);  // Удаляем тайл, заменяя его на null
        }
    }
}
