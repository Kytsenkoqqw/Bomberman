using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCharacter : MonoBehaviour
{
   public Action Death;
   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.CompareTag("Enemy"))
      {
         Death?.Invoke();
         Destroy(gameObject);
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("DamageArea"))
      {
         Death?.Invoke();
         Destroy(gameObject);
      }
   }
}
