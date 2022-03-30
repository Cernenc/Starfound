using Assets.Script.PlayableCharacters.Interfaces;
using Assets.Script.Statemachine.Interfaces;
using Assets.Script.PlayableCharacters.States.Support;
using UnityEngine;

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
        private Vector3 _playerMovement;
        public void Enter(ICharacter character)
        {
            _movement = new Movement();
            _movement.PlayerRigidbody = character.Components.Rigidbody;
            Cam.GameCamera.CanFollow = true;
        }

        public void Execute(ICharacter character)
        {
            _movement.HorizontalSpeed = character.AttributeManager.BaseSpeed;
            _movement.Limit = _movement.PlayerRigidbody.velocity.x;
            var horizontal = character.Horizontal * character.AttributeManager.MovementSpeed + (character.AttributeManager.BaseSpeed + character.SpeedCounter * character.AttributeManager.SpeedBoost);
            var vertical = character.Vertical * character.AttributeManager.JumpHeight;
            _playerMovement = new Vector3(horizontal, vertical);
            character.Components.Rigidbody.AddForce(_playerMovement);
            _movement.ForceHeadwind();
        }

        public void Exit(ICharacter character)
        {
            Cam.GameCamera.CanFollow = false;
        }
    }
}
