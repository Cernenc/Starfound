using Assets.Script.PlayableCharacters.Interfaces;
using Assets.Script.Statemachine.Interfaces;
using System;

namespace Assets.Script.PlayableCharacters.States
{
    public class WinningState : IEnterExecuteExit<ICharacter>
    {
        private static WinningState _instance;

        public static WinningState Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new WinningState();
                }

                return _instance;
            }
        }

        private WinningState()
        {
            _instance = this;
        }

        public void Enter(ICharacter character)
        {
            UnityEngine.Debug.Log("Entered Finish Line");
            character.Components.Rigidbody.isKinematic = true;
            character.Components.Rigidbody.useGravity = false;
        }

        public void Execute(ICharacter character)
        {
            UnityEngine.Debug.Log("Celebrating Finish Line");
        }

        public void Exit(ICharacter character)
        {
            UnityEngine.Debug.Log("Finishing Finish Line");
        }
    }
}
