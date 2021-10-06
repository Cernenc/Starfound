using Assets.Script.Enemies.Interfaces;
using Assets.Script.Support;
using Assets.Script.Statemachine.Interfaces;
using System;
using UnityEngine;

namespace Assets.Script.Enemies.Ants.States
{
    public class AntEnragedState : IEnterExecuteExit<IEnemy>
    {
        private static AntEnragedState _instance;
        public static AntEnragedState Instance
        {
            get
            {
                new AntEnragedState();
                return _instance;
            }
        }

        private AntEnragedState()
        {
            _instance = this;
        }


        private float _maxSpeed;
        private float _turnDelayTimer = 0;
        EnvironmentCheck check;
        public void Enter(IEnemy character)
        {
            _turnDelayTimer = Time.time;

            _maxSpeed = character.AttributeManager.Speed * 2;

            check = new EnvironmentCheck();
        }

        public void Execute(IEnemy character)
        {
            character.Components.Transform.Translate(new Vector3(_maxSpeed * Time.deltaTime, 0));

            Collider[] groundCheck = check.CheckForSurroundingGround(character.Components.Collider, LayerMask.GetMask("Ground"));

            if (groundCheck.Length < 1 && (Time.time - _turnDelayTimer > (1 / _maxSpeed)))
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
