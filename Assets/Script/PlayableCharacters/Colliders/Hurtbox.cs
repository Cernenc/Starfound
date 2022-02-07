using Assets.Script.Enemies.Interfaces;
using Assets.Script.PlayableCharacters.States;
using Assets.Script.PlayableCharacters.Interfaces;
using UnityEngine;
using Assets.Script.Core.Managers;
using Zenject;

namespace Assets.Script.PlayableCharacters.Colliders
{
    public class Hurtbox : MonoBehaviour
    {
        public ICharacter Player { get; set; }

        private void Awake()
        {
            Player = GetComponentInParent<ICharacter>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var enemy = other.GetComponent<IEnemy>();

            if (enemy != null)
            {
                Player.ChangeState(DamagedState.Instance);
                GetHitBy(enemy.AttributeManager.Damage);
            }
            else if (other.GetComponent<IEnemyProjectile>() != null)
            {
                enemy = other.GetComponentInParent<IEnemy>();
                Player.ChangeState(DamagedState.Instance);
                GetHitBy(enemy.AttributeManager.ProjectileDamage);
            }
        }

        private void GetHitBy(float damage)
        {
            //Manager.PlayerGauge.LoseGaugeByAmount(damage);
        }
    }
}