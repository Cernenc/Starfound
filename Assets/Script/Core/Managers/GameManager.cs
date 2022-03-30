using Assets.Script.PlayableCharacters.States.Support;
using System;

namespace Assets.Script.Core.Managers
{
    public interface IGameManager
    {
        StartingPointBehaviour StartingPoint { get; set; }

        void PauseGame();
    }

    public class GameManager : IGameManager
    {
        public StartingPointBehaviour StartingPoint { get; set; }

        public void PauseGame()
        {

        }
    }
}
