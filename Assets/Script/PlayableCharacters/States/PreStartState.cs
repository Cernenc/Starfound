using Assets.Script.Core.Managers;
using Assets.Script.PlayableCharacters.Interfaces;
using Assets.Script.PlayableCharacters.States.Support;
using Assets.Script.Statemachine.Interfaces;
using Zenject;

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

        private StartingPointBehaviour _startingPoint;
        public void Enter(ICharacter character)
        {
            _startingPoint = character.Manager.gameManager.StartingPoint;

            character.Components.Rigidbody.isKinematic = true;
            character.Components.Rigidbody.useGravity = false;
        }

        public void Execute(ICharacter character)
        {
            if(character.Manager.gameManager.StartingPoint == null)
            {
                character.ChangeState(FlyingState.Instance);
                return;
            }
            character.Components.Rigidbody.position = _startingPoint.MoveTowardsStart(character.Components.Rigidbody.position, character);
        }

        public void Exit(ICharacter character)
        {
            character.Components.Rigidbody.isKinematic = false;
            character.Components.Rigidbody.useGravity = true;
        }
    }
}
