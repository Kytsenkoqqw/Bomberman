using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public Tilemap tilemap;         // Ссылка на Tilemap для визуализации
    public Tile wallTile;           // Тайл для стен
    public Tile destructibleTile;   // Тайл для разрушаемых блоков
    public Tile emptyTile;          // Тайл для пустых клеток

    private int[,] grid;            // Массив, представляющий игровую сетку

    void Start()
    {
        grid = new int[25, 25]; // Размер 10x10 (можно изменить)
        GenerateGrid(); // Генерируем карту
        DrawGrid(); // Отображаем карту на Tilemap
    }

    // Метод для генерации карты
    void GenerateGrid()
    {
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                // Внешние стены
                if (x == 0 || y == 0 || x == grid.GetLength(0) - 1 || y == grid.GetLength(1) - 1)
                {
                    grid[x, y] = 1; // Стена
                }
                // Разрушаемые блоки (через случайность)
                else if (x % 2 == 0 && y % 2 == 0)
                {
                    grid[x, y] = 1; // Стена
                }
                else
                {
                    grid[x, y] = Random.Range(0, 2) == 0 ? 2 : 0; // 2 = Разрушаемый блок, 0 = Пусто
                }
            }
        }
    }

    // Метод для отображения карты на Tilemap
    void DrawGrid()
    {
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);

                // Размещение тайлов в зависимости от состояния клетки
                switch (grid[x, y])
                {
                    case 1:
                        tilemap.SetTile(tilePosition, wallTile); // Стена
                        break;
                    case 2:
                        tilemap.SetTile(tilePosition, destructibleTile); // Разрушаемый блок
                        break;
                    case 0:
                    default:
                        tilemap.SetTile(tilePosition, emptyTile); // Пустая клетка
                        break;
                }
            }
        }
    }
    
}
