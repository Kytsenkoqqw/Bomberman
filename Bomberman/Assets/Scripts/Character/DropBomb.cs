using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Improvements;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
   public ImprovementsData _data;
   public int  CountBomb;
   
   
   [SerializeField] private GameObject _bomb;

   private void Start()
   {
      _data.MaxCountBomb = 1;
   }

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
      Instantiate(_bomb, new Vector2(Mathf.Floor(transform.position.x) + 0.5f, Mathf.Floor(transform.position.y) + 0.5f), Quaternion.identity);
      CountBomb++;
      
      if (CountBomb >= _data.MaxCountBomb)
      {
         _placeBomb = true;
      }
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.CompareTag("ImprovingCountBomb"))
      {
         _data.MaxCountBomb++;
      }
   }
}
