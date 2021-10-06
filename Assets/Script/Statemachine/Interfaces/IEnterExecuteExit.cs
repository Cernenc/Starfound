namespace Assets.Script.Statemachine.Interfaces
{
    public interface IEnterExecuteExit<T>
    {
        void Enter(T character);
        void Execute(T character);
        void Exit(T character);
    }
}
