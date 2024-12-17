using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField] private float  _moveSpeed = 3f;

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;
        
        transform.Translate(moveHorizontal, moveVertical, 0);
    }
}
