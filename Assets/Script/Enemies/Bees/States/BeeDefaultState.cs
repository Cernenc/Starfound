using Assets.Script.Enemies.Interfaces;
using Assets.Script.Statemachine.Interfaces;

namespace Assets.Script.Enemies.Bees.States
{
    public class BeeDefaultState : IEnterExecuteExit<IEnemy>
    {
        private static BeeDefaultState _instance;
        public static BeeDefaultState Instance
        {
            get
            {
                _instance = new BeeDefaultState();
                return _instance;
            }
        }

        private BeeDefaultState() => _instance = this;

        public void Enter(IEnemy character)
        {

        }

        public void Execute(IEnemy character)
        {

        }

        public void Exit(IEnemy character)
        {

        }
    }
}
