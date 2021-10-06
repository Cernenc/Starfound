using Assets.Script.Enemies.Interfaces;
using UnityEngine;

namespace Assets.Script.Enemies.Attributes
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/EnemyAttributeManager", order = 2)]
    public class EnemyAttributeManager : ScriptableObject, IEnemyAttributeManager
    {
        [field: SerializeField]
        public float Damage { get; set; }

        [field: SerializeField]
        public float Speed { get; set; }

        #region Bees
        [field: SerializeField]
        public float ProjectileDamage { get; set; }

        [field: SerializeField]
        public float ProjectileInbetweenCooldown { get; set; }
        #endregion
    }
}