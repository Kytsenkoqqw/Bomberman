using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionBomb : MonoBehaviour
{
   [SerializeField] private Animator _animator;
   [SerializeField] private DropBomb _dropBomb;
   

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
     // _dropBomb._placeBomb = true;
      yield return new WaitForSeconds(2f);
      _animator.SetTrigger("Explosion");
      yield return  new WaitForSeconds(1.5f);
      _dropBomb._placeBomb = false;
      Destroy(gameObject);
   }
}
