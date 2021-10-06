using Assets.Script.Enemies.Attributes;
using Assets.Script.Enemies.Bees.States;
using Assets.Script.Enemies.Interfaces;
using Assets.Script.Statemachine;
using Assets.Script.Statemachine.Interfaces;
using UnityEngine;

namespace Assets.Script.Enemies.Bees
{
    public class BeeHive : MonoBehaviour, IEnemy
    {
        public IEnemyComponents Components { get; set; }

        [SerializeField]
        private EnemyAttributeManager _attributeManager = null;
        public IEnemyAttributeManager AttributeManager
        {
            get => _attributeManager;
        }

        private Statemachine<IEnterExecuteExit<IEnemy>, IEnemy> EnemyState { get; set; }

        [field: SerializeField]
        public GameObject[] Projectiles { get; set; }

        public void ChangeState(IEnterExecuteExit<IEnemy> newState)
        {
            EnemyState.ChangeState(newState);
        }

        private void Start()
        {
            Components = GetComponent<EnemyComponents>();
            EnemyState = new Statemachine<IEnterExecuteExit<IEnemy>, IEnemy>();
            EnemyState.CurrentCharacter = this;
            EnemyState.ChangeState(BeeDefaultState.Instance);
        }

        private void Update()
        {
            EnemyState.ExecuteCurrentState();
        }

        public void Spawn(GameObject projectile)
        {
            var bee = Instantiate(projectile) as GameObject;
            bee.transform.parent = transform;
        }
    }
}
