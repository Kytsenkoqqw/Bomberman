using System;
using Improvements;
using UnityEngine;

namespace Character
{
    public class TakeDetonator : MonoBehaviour
    {
        [SerializeField] private ImprovementsData _data;

        private void Start()
        {
            _data.Detonator = false;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("ImprovingDetonator"))
            {
                _data.Detonator = true;
            }
        }
    }
}