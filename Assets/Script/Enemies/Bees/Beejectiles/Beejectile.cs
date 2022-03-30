using Assets.Script.Core.Managers;
using Assets.Script.Enemies.Interfaces;
using Assets.Script.PlayableCharacters.Interfaces;
using UnityEngine;

namespace Assets.Script.Enemies.Bees.Beejectiles
{
    public class Beejectile : MonoBehaviour, IEnemyProjectile
    {
        public BeeHive Hive { get; set; }
        public PlayableCharacters.Interfaces.ICharacter Player { get; set; }
        private Vector3 TargetPosition { get; set; }
        public Vector2 MoveDirection { get; set; } = Vector2.zero;

        private float _timer = 0f;

        [field: SerializeField]
        public float LifeSpan { get; set; }

        public void Start()
        {
            Hive = GetComponentInParent<BeeHive>();
            TargetPosition = Player.Components.Rigidbody.position;
            MoveDirection = (TargetPosition - transform.position).normalized;
            _timer = Time.time;
        }

        private void Update()
        {
            Shoot();

            if(Time.time - _timer > LifeSpan)
            {
                DestroyProjectile();
            }
        }

        public void Shoot()
        {
            var direction = Hive.AttributeManager.Speed * Time.deltaTime * MoveDirection;
            transform.Translate(direction, Space.World);
        }

        public void DestroyProjectile()
        {
            Destroy(this.gameObject);
        }
    }
}
