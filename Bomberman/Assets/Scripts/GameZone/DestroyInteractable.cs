using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class DestroyInteractable : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;  // Ссылка на Tilemap
    [SerializeField] private Collider2D[] collider2D;
    [SerializeField] private GameObject[] _improvementPrefab;
    [SerializeField] private float improvementDropChance = 0.5f;
    
    private HashSet<Vector3Int> droppedPositions = new HashSet<Vector3Int>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DamageArea"))
        {
            // Преобразуем мировую позицию столкновения в координаты Tilemap
            Vector3Int tilePosition = tilemap.WorldToCell(other.transform.position);

            // Проверяем, было ли уже улучшение в этой клетке
            if (droppedPositions.Contains(tilePosition))
            {
                Debug.Log("Улучшение уже выпало в этой клетке.");
                return;
            }

            // Находим центр клетки
            Vector2 cellCenterPosition = tilemap.GetCellCenterWorld(tilePosition);

            // Поиск объектов только в пределах этой клетки
            Collider2D[] hitObjects = Physics2D.OverlapPointAll(cellCenterPosition);

            foreach (Collider2D hit in hitObjects)
            {
                if (hit.CompareTag("interactable")) 
                {
                    Debug.Log("bam");
                    Destroy(hit.gameObject);

                    // Решаем, будет ли выпадать улучшение
                    if (Random.value < improvementDropChance)
                    {
                        GameObject improvement = _improvementPrefab[Random.Range(0, _improvementPrefab.Length)];
                        Instantiate(improvement, cellCenterPosition, Quaternion.identity);

                        // Добавляем позицию клетки в HashSet
                        droppedPositions.Add(tilePosition);
                    }
                }
            }
        }
    }
}
