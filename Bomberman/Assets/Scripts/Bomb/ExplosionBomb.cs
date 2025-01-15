using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ExplosionBomb : MonoBehaviour
{
   private DropBomb _dropBomb;
   [SerializeField] private Animator _animator;
   [SerializeField] private GameObject[] _damageArea;

   private void OnEnable()
   {
      _animator.GetComponent<Animator>();
      _dropBomb = FindObjectOfType<DropBomb>();
   }

   private void Start()
   {
      StartCoroutine(Explosion());
   }

   private IEnumerator Explosion()
   {
      yield return new WaitForSeconds(2f);
      _animator.SetTrigger("Explosion");
      
      foreach (GameObject obj in _damageArea)
      {
         obj.SetActive(true);
      }

      yield return  new WaitForSeconds(1.5f);
      _dropBomb._placeBomb = false;
      
      foreach (GameObject obj in _damageArea)
      {
         obj.SetActive(false);
      }

      Destroy(gameObject);
      _dropBomb._countBomb = 0;
   }
}
