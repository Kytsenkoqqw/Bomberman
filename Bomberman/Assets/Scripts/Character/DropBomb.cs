using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
   public int _countBomb = 0;
   [SerializeField] private GameObject _bomb;
   
   public bool _placeBomb;
   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space) && !_placeBomb) 
      {
         PlaceBomb();
         if (_countBomb >=2)
         {
            _placeBomb = true;
         }
      }
   }

   private void PlaceBomb()
   {
      Instantiate(_bomb, new Vector2(Mathf.Floor(transform.position.x) + 0.5f, Mathf.Floor(transform.position.y) + 0.5f), Quaternion.identity);
      _countBomb++;
   }
   
}
