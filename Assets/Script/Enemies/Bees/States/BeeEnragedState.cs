using Assets.Script.Enemies.Interfaces;
using Assets.Script.Statemachine.Interfaces;
using UnityEngine;

namespace Assets.Script.Enemies.Bees.States
{
    public class BeeEnragedState : IEnterExecuteExit<IEnemy>
    {
        private static BeeEnragedState _instance = null;
        public static BeeEnragedState Instance
        {
            get
            {
                _instance = new BeeEnragedState();
                return _instance;
            }
        }

        private BeeEnragedState() => _instance = this;

        private float _timer = 0;
        private BeeHive _bee;
        private int _currentProjectileNo = 0;

        public void Enter(IEnemy character)
        {
            _timer = Time.time;
            _bee = character.Components.Transform.GetComponent<BeeHive>();
        }

        public void Execute(IEnemy character)
        {
            if(Time.time - _timer > character.AttributeManager.ProjectileInbetweenCooldown)
            {
                _bee.Spawn(_bee.Projectiles[_currentProjectileNo]);
                _currentProjectileNo++;
                _timer = Time.time;
            }
            if (_currentProjectileNo == _bee.Projectiles.Length)
            {
                character.ChangeState(BeeDefaultState.Instance);
            }
        }

        public void Exit(IEnemy character)
        {
            UnityEngine.Debug.Log("Bee enraged no more");
        }
    }
}
