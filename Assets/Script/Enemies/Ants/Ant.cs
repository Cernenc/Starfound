using Assets.Script.Enemies.Ants.States;
using Assets.Script.Enemies.Attributes;
using Assets.Script.Enemies.Interfaces;
using Assets.Script.Statemachine;
using Assets.Script.Statemachine.Interfaces;
using UnityEngine;

namespace Assets.Script.Enemies.Ants
{
    public class Ant : MonoBehaviour, IEnemy
    {
        public IEnemyComponents Components { get; set; }

        [SerializeField]
        private EnemyAttributeManager _attributeManager = null;
        public IEnemyAttributeManager AttributeManager
        {
            get => _attributeManager;
        }

        private Statemachine<IEnterExecuteExit<IEnemy>, IEnemy> EnemyState { get; set; }

        public void Start()
        {
            Components = GetComponent<EnemyComponents>();
            EnemyState = new Statemachine<IEnterExecuteExit<IEnemy>, IEnemy>();
            EnemyState.CurrentCharacter = this;
            ChangeState(AntDefaultState.Instance);
        }

        public void Update()
        {
            EnemyState.ExecuteCurrentState();
        }

        public void ChangeState(IEnterExecuteExit<IEnemy> newState)
        {
            EnemyState.ChangeState(newState);
        }
    }
}
