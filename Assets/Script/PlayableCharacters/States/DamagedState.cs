using Assets.Script.Statemachine.Interfaces;
using Assets.Script.PlayableCharacters.Interfaces;
using Assets.Script.PlayableCharacters.States.Support;

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
            character.Components.Rigidbody.isKinematic = true;
            _startingPoint = character.StartingPoint;
            character.Components.Hurtbox.enabled = false;
        }

        public void Execute(ICharacter character)
        {
            character.Components.Rigidbody.position = _startingPoint.MoveTowardsStart(character.Components.Rigidbody.position, character);
        }

        public void Exit(ICharacter character)
        {
            character.Components.Rigidbody.isKinematic = false;
            character.SpeedCounter = 0;

            character.IsInvincible?.Invoke();
        }
    }
}
