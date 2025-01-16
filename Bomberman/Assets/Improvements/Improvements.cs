using UnityEngine;

namespace Improvements
{
    [CreateAssetMenu(fileName = "ImprovementsData", menuName = "Game/Improvements")]
    public class ImprovementsData : ScriptableObject
    {
        public float MoveSpeed;
        public int MaxCountBomb;
        public bool Detonator;
    }
}