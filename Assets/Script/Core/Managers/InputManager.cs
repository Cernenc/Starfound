using Assets.Script.PlayableCharacters.States.Support;
using UnityEngine;

namespace Assets.Script.Core.Managers
{
    public class InputManager : GameBehaviour
    {
        public void Update()
        {
            if (playerManager.Player != null)
            {
                JumpInput();
                ActivateItem();
                PauseGame();
            }
        }

        private void PauseGame()
        {
            if (Input.GetButtonDown("Cancel") && gameManager.CanPause)
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
            if (gameManager.PlayerInventory != null)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    if (gameManager.PlayerInventory.SpeedupnoteList.Count > 0)
                    {
                        gameManager.PlayerInventory.SpeedupnoteList[0].OnActivation();
                    }
                }
                else if (Input.GetButtonDown("Fire2"))
                {
                    if (gameManager.PlayerInventory.SpinnoteList.Count > 0)
                    {
                        gameManager.PlayerInventory.SpinnoteList[0].OnActivation();
                    }
                }
            }
        }
    }
}
