using System;
using Improvements;
using UnityEngine;

namespace Character
{
    public class TakeDamageAreaImproving : MonoBehaviour
    {
        [SerializeField] private DropBomb _dropBomb;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("ImprovingDamageArea"))
            {
                _dropBomb.IsLevelUpBomb = true;
            }
        }
    }
}