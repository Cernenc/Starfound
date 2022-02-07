using Assets.Script.PlayableCharacters.Interfaces;
using Assets.Script.Statemachine.Interfaces;
using Assets.Script.PlayableCharacters.Health;
using Assets.Script.PlayableCharacters.States.Support;
using UnityEngine;
using System;
using Zenject;
using Assets.Script.Core.Managers;

namespace Assets.Script.PlayableCharacters.States
{
    public class FlyingState : IEnterExecuteExit<ICharacter>
    {
        private static FlyingState _instance;

        public static FlyingState Instance
        {
            get
            {
                if (_instance == null)
                {
                    new FlyingState();
                }
                return _instance;
            }
        }

        private FlyingState()
        {
            _instance = this;
        }

        private Movement _movement;

        public void Enter(ICharacter character)
        {
            _movement = new Movement();
            _movement.Character = character;

            Cam.CameraMovement.CanFollow = true;
            character.Manager.animationManager.MoveAnimation();

            if (Invulnerability.IsInvincible)
            {
                character.Manager.playerManager.OnInvincibility.Invoke();
            }
        }

        public void Execute(ICharacter character)
        {
            _movement.ForceMovement(character.AttributeManager.MovementSpeed + character.Manager.gameManager.SpeedCounter * character.AttributeManager.SpeedBoost);
            _movement.ForceHeadwind(character.Components.Rigidbody.velocity.x);

            character.Manager.gameManager.Gauge.DrainGauge(Time.deltaTime);

            if(Invulnerability.IsInvincible == false)
            {
                character.Manager.playerManager.OnIsDamageable.Invoke();
            }
        }

        public void Exit(ICharacter character)
        {
            Cam.CameraMovement.CanFollow = false;
        }
    }
}
