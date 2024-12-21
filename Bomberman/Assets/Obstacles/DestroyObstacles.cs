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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DamageArea"))
        {
            // Преобразуем мировую позицию столкновения в координаты Tilemap
            Vector3Int tilePosition = tilemap.WorldToCell(other.transform.position);

            // Поиск объекта, который был инстанцирован в этой клетке
            Vector3 worldPosition = tilemap.CellToWorld(tilePosition);
            Collider2D[] hitObjects = Physics2D.OverlapPointAll(worldPosition);

            foreach (Collider2D hit in hitObjects)
            {
                if (hit.CompareTag("interactable"))  // Убедись, что у префаба есть нужный тег
                {
                    Debug.Log("bam");
                    Destroy(hit.gameObject);  // Удаляем объект
                }
            }
        }
    }
}
