using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Improvements;
using TMPro;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
   public ImprovementsData _data;
   public int  CountBomb;
   public GameObject Bomb;
   public bool IsLevelUpBomb;
   [SerializeField] private TextMeshProUGUI  _countBombText;
   
   

   private void Start()
   {
      IsLevelUpBomb = false;
      _data.MaxCountBomb = 1;
      CountBomb = 1;
      _countBombText.text = "Count Bomb: " + _data.MaxCountBomb;
   }

   public bool _placeBomb;
   
   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space) && !_placeBomb && !IsLevelUpBomb) 
      {
         PlaceBomb(Bomb);
      }
      else if (IsLevelUpBomb && Input.GetKeyDown(KeyCode.Space) && !_placeBomb)
      {
         PlaceBomb(_data.DamageArea);
      }
   }

   private void PlaceBomb(GameObject bombPrefab)
   {
      Instantiate(bombPrefab, new Vector2(Mathf.Floor(transform.position.x) + 0.5f, Mathf.Floor(transform.position.y) + 0.5f), Quaternion.identity);
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
         _countBombText.text = "Count Bomb: " + _data.MaxCountBomb;
      }
   }
}
