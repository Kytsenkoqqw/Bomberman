using System;
using System.Collections;
using System.Collections.Generic;
using Improvements;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField] private ImprovementsData _data;
    [SerializeField] private TextMeshProUGUI _moveSpeedText;
    private int _lvlMoveSpeed;
    

    private void Start()
    {
        _lvlMoveSpeed = 0;
        _data.MoveSpeed = 3f;
        _moveSpeedText.text = "MoveSpeed: " + _lvlMoveSpeed;
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * _data.MoveSpeed * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * _data.MoveSpeed * Time.deltaTime;
        
        transform.Translate(moveHorizontal, moveVertical, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ImprovingSpeed"))
        {
            _data.MoveSpeed += 1.5f;
            _moveSpeedText.text = "MoveSpeed: " + _lvlMoveSpeed++;
        }
    }
}
