using Assets.Script.PlayableCharacters.States.Support;
using Assets.Script.UI.Menu;
using System;
using UnityEngine;

namespace Assets.Script.Core.Managers
{
    public class GameManagerBehaviour : MonoBehaviour
    {
        [field: SerializeField]
        public ManagerDependencyInjection Injection { get; set; }
        [field: SerializeField]
        public PauseMenu pauseMenu { get; set; }
        [field: SerializeField]
        public WinningMenu winningMenu { get; set; }
        [field: SerializeField]
        public DeathMenu deathMenu { get; set; }
        [field: SerializeField]
        public StartingPointBehaviour StartingPoint { get; set; }

        public void Awake()
        {
            Injection.gameManager.pauseMenu = pauseMenu;
            Injection.gameManager.winningMenu = winningMenu;
            Injection.gameManager.deathMenu = deathMenu;
            Injection.gameManager.StartingPoint = StartingPoint;
            Injection.playerManager.OnInvincibility += HandleInvincibility;
        }

        private void HandleInvincibility()
        {
            StartCoroutine(Injection.gameManager.InvulnerableBehaviour.FlashCo(Injection.playerManager.Player.AttributeManager.IFrames, 0.15f, Injection.animationManager.Flashing));
        }
    }
}
