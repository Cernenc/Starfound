using Assets.Script.Inventories;
using Assets.Script.PlayableCharacters.Health;
using Assets.Script.PlayableCharacters.States;
using Assets.Script.PlayableCharacters.States.Support;
using Assets.Script.UI.Menu;
using UnityEngine;
using Zenject;

namespace Assets.Script.Core.Managers
{
    public interface IGameManager
    {
        void Setup();
        void GaugeSetup();
        void PlayerEventsSetup();
        IGauge Gauge { get; set; }
        bool CanPause { get; }
        IInventory PlayerInventory { get; set; }
        PauseMenu pauseMenu { get; set; }
        WinningMenu winningMenu { get; set; }
        DeathMenu deathMenu { get; set; }
        int Score { get; set; }
        int SpeedCounter { get; set; }
        StartingPointBehaviour StartingPoint { get; set; }
        Invulnerability InvulnerableBehaviour { get; set; }
    }

    public class GameManager : IGameManager
    {
        public bool CanPause { get; private set; }

        public Invulnerability InvulnerableBehaviour { get; set; }
        public PauseMenu pauseMenu { get; set; }
        public WinningMenu winningMenu { get; set; }
        public DeathMenu deathMenu { get; set; }

        [Inject]
        public IInventory PlayerInventory { get; set; }

        public int Score { get; set; }

        public int SpeedCounter { get; set; } = 0;

        [Inject]
        public IGauge Gauge { get; set; }

        public StartingPointBehaviour StartingPoint { get; set; }

        [Inject]
        private IPlayerManager playerManager { get; set; }

        [Inject]
        private IAnimationManager animationManager { get; set; }

        public void Setup()
        {
            InvulnerableBehaviour = new Invulnerability();
            CanPause = true;
            pauseMenu.OnPauseGame += HandlePauseGame;
        }

        public void GaugeSetup()
        {
            Gauge = new Gauge();
            Gauge.MaxGaugeAmount = playerManager.Player.AttributeManager.GaugeMaxAmount;
            Gauge.CurrentGaugeAmount = Gauge.MaxGaugeAmount;
            Gauge.GaugeLossAmountPerSecond = playerManager.Player.AttributeManager.GaugeLossAmountPerSecond;
            Gauge.OnEmptyGauge += HandleDeath;
        }

        public void PlayerEventsSetup()
        {
            playerManager.OnSetPlayer += HandleSetPlayer;
            playerManager.OnInvincibility += HandleInvincibility;
            playerManager.OnIsDamageable += HandleCanBeDamaged;
            playerManager.OnLevelClear += HandleLevelCleared;
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
