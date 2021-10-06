using Assets.Script.PlayableCharacters.Interfaces;
using Assets.Script.Statemachine.Interfaces;

namespace Assets.Script.PlayableCharacters.States
{
    public class DyingState : IEnterExecuteExit<ICharacter>
    {
        private DyingState()
        {
            _instance = this;
        }

        private static DyingState _instance;

        public static DyingState Instance
        {
            get
            {
                if(_instance == null)
                {
                    new DyingState();
                }

                return _instance;
            }
        }

        public void Enter(ICharacter character)
        {
            character.Components.Rigidbody.isKinematic = true;
            character.Components.Rigidbody.useGravity = false;
            character.SpeedCounter = 0;
        }

        public void Execute(ICharacter character)
        {
        }

        public void Exit(ICharacter character)
        {
        }
    }
}
