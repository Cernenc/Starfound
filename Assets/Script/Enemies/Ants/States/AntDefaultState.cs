using Assets.Script.Enemies.Interfaces;
using Assets.Script.Support;
using Assets.Script.Statemachine.Interfaces;
using UnityEngine;

namespace Assets.Script.Enemies.Ants.States
{
    public class AntDefaultState : IEnterExecuteExit<IEnemy>
    {
        private static AntDefaultState _instance;
        public static AntDefaultState Instance
        {
            get
            {
                _instance = new AntDefaultState();
                return _instance;
            }
        }

        private AntDefaultState() => _instance = this;

        private float _turnDelayTimer = 0;
        EnvironmentCheck check;

        public void Enter(IEnemy character)
        {
            _turnDelayTimer = Time.time;
            check = new EnvironmentCheck();
        }

        public void Execute(IEnemy character)
        {
            character.Components.Transform.Translate(new Vector3(character.AttributeManager.Speed * Time.deltaTime, 0));

            Collider[] groundCheck = check.CheckForSurroundingGround(character.Components.Collider, LayerMask.GetMask("Ground"));

            if (groundCheck.Length < 1 && (Time.time - _turnDelayTimer > (1 / character.AttributeManager.Speed)))
            {
                character.Components.Transform.Rotate(new Vector3(0, 180, 0));

                _turnDelayTimer = Time.time;
            }
        }

        public void Exit(IEnemy character)
        {
        }
    }
}
