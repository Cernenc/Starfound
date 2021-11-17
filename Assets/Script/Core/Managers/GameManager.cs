using Assets.Script.Inventories;
using Assets.Script.PlayableCharacters.States;
using Assets.Script.UI.Menu;
using UnityEngine;
using Zenject;

namespace Assets.Script.Core.Managers
{
    public class GameManager : GameBehaviour
    {
        public bool CanPause { get; private set; }

        private Invulnerability Invincibility { get; set; }

        [field: SerializeField]
        public PauseMenu pauseMenu { get; set; }

        [field: SerializeField]
        public WinningMenu winningMenu { get; set; }

        [field: SerializeField]
        public DeathMenu deathMenu { get; set; }

        [Inject]
        public IInventory PlayerInventory { get; set; }

        private void Awake()
        {
            playerManager.OnSetPlayer += HandleSetPlayer;
            playerManager.OnDeath += HandleDeath;
            playerManager.OnLevelClear += HandleLevelCleared;
            playerManager.OnInvincibility += HandleInvincibility;
            playerManager.OnDamageable += HandleCanBeDamaged;
            Invincibility = new Invulnerability();
            CanPause = true;
            pauseMenu.OnPauseGame += HandlePauseGame;
        }

        private void HandleSetPlayer()
        {
            animationManager.PlayerAnimator = playerManager.Player.Components.PlayerAnimator;
        }

        private void HandlePauseGame()
        {
            pauseMenu.PauseUnpause();
        }

        private void HandleCanBeDamaged()
        {
            playerManager.Player.Components.Hurtbox.enabled = true;
            animationManager.ScaleModelTo(Vector3.one);
        }

        private void HandleInvincibility()
        {
            StartCoroutine(Invincibility.FlashCo(playerManager.Player.AttributeManager.IFrames, 0.15f, animationManager.Flashing));
        }

        private void HandleLevelCleared()
        {
            winningMenu.WinningMenuObject.SetActive(true);
            winningMenu.LevelClear();
            animationManager.IdleAnimation();
            playerManager.Player.ChangeState(WinningState.Instance);
            CanPause = false;
        }

        private void HandleDeath()
        {
            deathMenu.DeathMenuObject.SetActive(true);
            deathMenu.LevelLost();
            animationManager.DeathAnimation();
            playerManager.Player.ChangeState(DyingState.Instance);
            CanPause = false;
        }
    }
}
