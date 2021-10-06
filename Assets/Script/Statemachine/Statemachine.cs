using Assets.Script.Statemachine.Interfaces;

namespace Assets.Script.Statemachine
{
    public class Statemachine<T, DetermindedCharacter> where T : IEnterExecuteExit<DetermindedCharacter>
    {
        private T _currentState = default;

        public DetermindedCharacter CurrentCharacter { get; set; }

        public void ChangeState(T newState)
        {
            if(_currentState != null)
            {
                _currentState.Exit(CurrentCharacter);
            }
            _currentState = newState;
            _currentState.Enter(CurrentCharacter);
        }

        public void ExecuteCurrentState()
        {
            if(_currentState != null)
            {
                _currentState.Execute(CurrentCharacter);
            }
        }
    }
}