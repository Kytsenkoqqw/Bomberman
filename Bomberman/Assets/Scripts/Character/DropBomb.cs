using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
   [SerializeField] private GameObject _bomb;
   public bool _placeBomb;

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space) && !_placeBomb) 
      {
         PlaceBomb();
      }
   }

   private void PlaceBomb()
   {
      _placeBomb = true;
      Instantiate(_bomb, new Vector2(Mathf.Floor(transform.position.x) + 0.5f, Mathf.Floor(transform.position.y) + 0.5f), Quaternion.identity);
   }
   
}
