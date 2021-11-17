using Assets.Script.PlayableCharacters.Interfaces;
using Assets.Script.Statemachine.Interfaces;
using Assets.Script.PlayableCharacters.Health;
using Assets.Script.PlayableCharacters.States.Support;
using UnityEngine;
using System;

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

        private float _drainAmount;
        private Movement _movement;
        public void Enter(ICharacter character)
        {
            GaugeSetup(character);
            _movement = new Movement();
            _movement.Character = character;

            Cam.CameraMovement.CanFollow = true;
            character.animationManager.MoveAnimation();

            if (Invulnerability.IsInvincible)
            {
                character.playerManager.OnInvincibility();
            }
        }

        public void Execute(ICharacter character)
        {
            _movement.ForceMovement(character.AttributeManager.MovementSpeed + character.SpeedCounter * character.AttributeManager.SpeedBoost);
            _movement.ForceHeadwind(character.Components.Rigidbody.velocity.x);

            character.PlayerGauge.DrainGauge(_drainAmount * Time.deltaTime);

            if(Invulnerability.IsInvincible == false)
            {
                character.playerManager.OnDamageable();
            }
        }

        public void Exit(ICharacter character)
        {
            Cam.CameraMovement.CanFollow = false;
        }

        private void GaugeSetup(ICharacter character)
        {
            character.PlayerGauge.MaxGaugeAmount = character.AttributeManager.GaugeMaxAmount;
            character.PlayerGauge.OnEmptyGauge += HandleEmptyGauge;
            _drainAmount = character.AttributeManager.GaugeLossAmountPerSecond;
        }

        private void HandleEmptyGauge(Action action)
        {
            action();
        }
    }
}
