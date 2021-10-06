using Assets.Script.Core.Managers;
using Assets.Script.Enemies.Interfaces;
using Assets.Script.PlayableCharacters.Interfaces;
using UnityEngine;

namespace Assets.Script.Enemies.Bees.Beejectiles
{
    public class Beejectile : MonoBehaviour, IEnemyProjectile
    {
        public BeeHive Hive { get; set; }
        public ICharacter Player { get; set; }
        private Vector3 TargetPos { get; set; }
        
        private float _timer = 0f;

        [field: SerializeField]
        public float LifeSpan { get; set; }

        public void Start()
        {
            Hive = GetComponentInParent<BeeHive>();
            Player = FindObjectOfType<PlayerManager>().Player;
            TargetPos = Player.Components.Rigidbody.position.normalized;
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
            transform.Translate(Hive.AttributeManager.Speed * Time.deltaTime * TargetPos, Space.World);
        }

        public void DestroyProjectile()
        {
            Destroy(this.gameObject);
        }
    }
}
