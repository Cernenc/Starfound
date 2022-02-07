using Assets.Script.PlayableCharacters.States.Support;
using UnityEngine;
using Zenject;

namespace Assets.Script.Core.Managers
{
    public interface IInputManager
    {
        void ManageInputs();
    }

    public class InputManager : IInputManager
    {
        [Inject]
        private IPlayerManager playerManager { get; set; }

        [Inject]
        private IGameManager gameManager { get; set; }

        public void ManageInputs()
        {
            if(playerManager.Player == null)
            {
                return;
            }
            JumpInput();
            ActivateItem();
            PauseGame();
        }

        private void PauseGame()
        {
            if (!gameManager.CanPause)
            {
                return;
            }
            if (Input.GetButtonDown("Cancel"))
            {
                gameManager.pauseMenu.OnPauseGame();
            }
        }

        private void JumpInput()
        {
            if (Input.GetButton("Jump"))
            {
                Movement.VerticalMovement = playerManager.Player.AttributeManager.JumpHeight;
            }
            else
            {
                Movement.VerticalMovement = -playerManager.Player.AttributeManager.FallSpeed;
            }
        }

        private void ActivateItem()
        {
            if (gameManager.PlayerInventory == null)
            {
                return;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                if (gameManager.PlayerInventory.SpeedupnoteList.Count == 0)
                {
                    return;
                }

                gameManager.PlayerInventory.SpeedupnoteList[0].OnActivation.Invoke();
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                if (gameManager.PlayerInventory.SpinnoteList.Count == 0)
                {
                    return;
                }

                gameManager.PlayerInventory.SpinnoteList[0].OnActivation.Invoke();
            }
        }
    }
}
