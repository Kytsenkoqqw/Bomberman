using System;
using System.Collections;
using System.Collections.Generic;
using Improvements;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ExplosionBomb : MonoBehaviour
{
   private DropBomb _dropBomb;
   [SerializeField] private ImprovementsData _data;
   
   [SerializeField] private Animator _animator;
   [SerializeField] private GameObject[] _damageArea;

   private void OnEnable()
   {
      _animator.GetComponent<Animator>();
      _dropBomb = FindObjectOfType<DropBomb>();
   }

   private void Start()
   {
      if (!_data.Detonator)
      {
         StartCoroutine(Explosion());
      }
   }

   private void Update()
   {
      if (_data.Detonator)
      {
         if (Input.GetKeyDown(KeyCode.R))
         {
            StartCoroutine(Detonator());
         }
      }
   }

   private IEnumerator Detonator()
   {
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
      _dropBomb.CountBomb = 0;
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
      _dropBomb.CountBomb = 0;
   }
}
