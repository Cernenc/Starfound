using Assets.Script.Statemachine.Interfaces;
using Assets.Script.PlayableCharacters.Interfaces;
using Assets.Script.PlayableCharacters.States.Support;
using Assets.Script.Core.Managers;
using Zenject;

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

        private StartingPointBehaviour _startingPoint;
        public void Enter(ICharacter character)
        {
            SetupRigidbody(character);

            _startingPoint = character.Manager.gameManager.StartingPoint;
            character.Manager.animationManager.HitAnimation();
            character.Components.Hurtbox.enabled = false;
        }

        public void Execute(ICharacter character)
        {
            character.Components.Rigidbody.position = _startingPoint.MoveTowardsStart(character.Components.Rigidbody.position, character);
        }

        public void Exit(ICharacter character)
        {
            SetupRigidbody(character);
            character.Manager.gameManager.SpeedCounter = 0;
            Invulnerability.IsInvincible = true;
        }

        private static void SetupRigidbody(ICharacter character)
        {
            character.Components.Rigidbody.useGravity = !character.Components.Rigidbody.useGravity;
            character.Components.Rigidbody.isKinematic = !character.Components.Rigidbody.isKinematic;
        }
    }
}
