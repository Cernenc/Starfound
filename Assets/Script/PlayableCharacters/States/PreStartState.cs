using Assets.Script.Core.Managers;
using Assets.Script.PlayableCharacters.Interfaces;
using Assets.Script.PlayableCharacters.States.Support;
using Assets.Script.Statemachine.Interfaces;

namespace Assets.Script.PlayableCharacters.States
{
    public class PreStartState : IEnterExecuteExit<ICharacter>
    {
        private static PreStartState _instance = new PreStartState();
        public static PreStartState Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new PreStartState();
                }

                return _instance;
            }
        }

        private StartingPoint _startPosition;

        public void Enter(ICharacter character)
        {
            character.Components.Rigidbody.isKinematic = true;
            character.Components.Rigidbody.useGravity = false;

            _startPosition = character.playerManager.StartPosition;
        }

        public void Execute(ICharacter character)
        {
            if (!_startPosition)
            {
                character.ChangeState(FlyingState.Instance);
            }
            else
            {
                character.Components.Rigidbody.position = _startPosition.AtStartPosition(character.Components.Rigidbody.position, character);

            }
        }

        public void Exit(ICharacter character)
        {
            character.Components.Rigidbody.isKinematic = false;
            character.Components.Rigidbody.useGravity = true;
        }
    }
}
