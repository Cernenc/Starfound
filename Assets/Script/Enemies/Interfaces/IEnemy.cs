using Assets.Script.Statemachine.Interfaces;

namespace Assets.Script.Enemies.Interfaces
{
    public interface IEnemy
    {
        IEnemyComponents Components{ get; set; }
        IEnemyAttributeManager AttributeManager { get; }
        void ChangeState(IEnterExecuteExit<IEnemy> newState);
    }
}
