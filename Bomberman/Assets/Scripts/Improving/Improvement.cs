using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Improvement : MonoBehaviour
{
    public Improving.Improving Type; // Тип улучшения
    public float Value;    // Значение улучшения (например, увеличение скорости)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Проверка, что это персонаж
        {
            CharacterBehaviour character = other.GetComponent<CharacterBehaviour>();
            if (character != null)
            {
                character.ApplyImprovement(Type, Value);
                Destroy(gameObject); // Удаляем улучшение с карты
            }
        }
    }
}
