using Assets.Script.PlayableCharacters.Interfaces;
using UnityEngine;
using Zenject;

namespace Assets.Script.Core.Managers
{
    public class ManagerDependencyInjection : MonoBehaviour
    {
        [SerializeField]
        private PlayableCharacters.Star _player = null;
        public ICharacter Player => _player;
        public IGameManager gameManager { get; private set; }
        public IPlayerManager playerManager { get; private set; }
        public IInputManager inputManager { get; private set; }
        public IAnimationManager animationManager { get; private set; }

        [Inject]
        public void Setup(IGameManager gameManager, IPlayerManager playerManager, IInputManager inputManager, IAnimationManager animationManager)
        {
            this.gameManager = gameManager;
            this.playerManager = playerManager;
            this.inputManager = inputManager;
            this.animationManager = animationManager;
        }

        public void Start()
        {
            gameManager.Setup();
            gameManager.PlayerEventsSetup();
            playerManager.Player = _player;
            gameManager.GaugeSetup();
            animationManager.MoveAnimation();
        }

        private void Update()
        {
            inputManager.ManageInputs();
        }
    }
}
