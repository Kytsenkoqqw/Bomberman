using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCharacter : MonoBehaviour
{
   public Action Death;
   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.GetComponent<EnemyBehaviour>())
      {
         Death?.Invoke();
         Destroy(gameObject);
      }
   }
}
