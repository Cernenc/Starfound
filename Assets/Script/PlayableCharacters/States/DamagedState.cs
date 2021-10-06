using Assets.Script.Statemachine.Interfaces;
using Assets.Script.PlayableCharacters.Interfaces;
using Assets.Script.PlayableCharacters.States.Support;
using Assets.Script.Core.Managers;

namespace Assets.Script.PlayableCharacters.States
{
    public class DamagedState : IEnterExecuteExit<ICharacter>
    {
        private static DamagedState _instance;
        public static DamagedState Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new DamagedState();
                }

                return _instance;
            }
        }

        private DamagedState() => _instance = this;

        private StartingPoint _startPosition;
        public void Enter(ICharacter character)
        {
            SetupRigidbody(character);

            _startPosition = character.playerManager.StartPosition;
            character.animationManager.HitAnimation();
            character.Components.Hurtbox.enabled = false;
        }

        public void Execute(ICharacter character)
        {
            character.Components.Rigidbody.position = _startPosition.AtStartPosition(character.Components.Rigidbody.position, character);
        }

        public void Exit(ICharacter character)
        {
            SetupRigidbody(character);
            character.SpeedCounter = 0;
            Invulnerability.IsInvincible = true;
        }

        private static void SetupRigidbody(ICharacter character)
        {
            character.Components.Rigidbody.useGravity = !character.Components.Rigidbody.useGravity;
            character.Components.Rigidbody.isKinematic = !character.Components.Rigidbody.isKinematic;
        }
    }
}
