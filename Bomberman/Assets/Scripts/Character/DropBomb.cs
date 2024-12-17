using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
   [SerializeField] private GameObject _bomb;
   [SerializeField] private Transform _characterTransform;
   
   private bool _placeBomb;

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space) && !_placeBomb) 
      {
         _placeBomb = true;
         Explosion();
      }
   }

   private void Explosion()
   {
      if (_placeBomb)
      {
         StartCoroutine(ExplosionBomb());
      }
   }

   private IEnumerator ExplosionBomb()
   {
      if (_placeBomb)
      {
         var currentBomb = Instantiate(_bomb, _characterTransform.position, Quaternion.identity);
         yield return new WaitForSeconds(2f);
         Destroy(currentBomb);
         _placeBomb = false;
      }
   }
}
