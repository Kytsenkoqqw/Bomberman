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

            // Находим центр клетки
            Vector3 cellCenterPosition = tilemap.GetCellCenterWorld(tilePosition);

            // Поиск объектов только в пределах этой клетки
            Collider2D[] hitObjects = Physics2D.OverlapPointAll(cellCenterPosition);

            foreach (Collider2D hit in hitObjects)
            {
                if (hit.CompareTag("interactable")) 
                {
                    Debug.Log("bam");
                    Destroy(hit.gameObject);
                    
                    if (Random.value < improvementDropChance)
                    {
                        GameObject improvment = _improvementPrefab[Random.Range(0, _improvementPrefab.Length)];
                        Instantiate(improvment, cellCenterPosition, Quaternion.identity);
                    }
                }
            }
        }
    }
}
