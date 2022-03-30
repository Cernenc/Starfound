using Assets.Script.CharacterSelection;
using Assets.Script.Factories;
using Assets.Script.LevelSelection;
using Assets.Script.PlayableCharacters.Interfaces;
using Assets.Script.PlayableCharacters.States.Support;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Script.Core.Managers
{
    public class ManagerDependencyInjection : MonoBehaviour
    {
        public LevelSelect LevelSelection;
        private GameObject LevelGo;
        public Transform SceneParentTransform;
        public CharacterSelect CharacterSelection;
        private Factory _characterFactory;
        private CharacterFactory.Settings _characterSettings;
        private StartingPointBehaviour StartingPoint { get; set; }

        [Inject]
        public void Construct(Factory characterFactory, CharacterFactory.Settings characterSettings)
        {
            _characterFactory = characterFactory;
            _characterSettings = characterSettings;
        }

        public IGameManager gameManager { get; private set; }
        public IPlayerManager playerManager { get; private set; }
        public IInputManager inputManager { get; private set; }
        public IAnimationManager animationManager { get; private set; }
        public IMenuManager menuManager { get; private set; }
        public ILevelManager levelManager { get; private set; }

        [Inject]
        public void Setup(IGameManager gameManager, IPlayerManager playerManager, IInputManager inputManager, IAnimationManager animationManager, IMenuManager menuManager, ILevelManager levelManager)
        {
            this.gameManager = gameManager;
            this.playerManager = playerManager;
            this.inputManager = inputManager;
            this.animationManager = animationManager;
            this.menuManager = menuManager;
            this.levelManager = levelManager;
        }

        private void Start()
        {
            CharacterSelection.OnSelectCharacter = new UnityEngine.Events.UnityEvent();
            CharacterSelection.OnSelectCharacter.AddListener(HandleSelectCharacter);

            LevelSelection.OnStartGame = new GameStartEvent();
            LevelSelection.OnStartGame.AddListener(HandleStartGame);
            InputActionSetup();
        }

        private void InputActionSetup()
        {
            inputManager.OnInputHorizontalMovement += playerManager.HandleHorizontalMovement;
            inputManager.OnInputVerticalMovement += playerManager.HandleVerticalMovement;
            inputManager.OnInputSpecial += animationManager.SpecialMoveAnimation;
            inputManager.OnInputSpecial += playerManager.SpecialMove;
            inputManager.OnInputPause += gameManager.PauseGame;
        }
        


        private void Update()
        {
            if(playerManager.Player == null)
            {
                return;
            }

            if (Input.GetButtonDown("Jump"))
            {
                inputManager.OnInputSpecial?.Invoke();
            }

            inputManager.Horizontal = Input.GetAxisRaw("Horizontal");
            
            inputManager.Vertical = Input.GetAxisRaw("Vertical");
        }

        private void HandleStartGame(GameObject go)
        {
            LevelGo = go;
            var level = Instantiate(LevelGo, SceneParentTransform);
            playerManager.Player = _characterFactory.Create();
            playerManager.Player.IsInvincible = new UnityEngine.Events.UnityEvent();
            playerManager.Player.IsInvincible.AddListener(animationManager.Flashing);
            StartingPoint = level.GetComponentInChildren<StartingPointBehaviour>();
            playerManager.Player.StartingPoint = StartingPoint;
        }

        private void HandleSelectCharacter()
        {
            _characterSettings.PlayerCharacter = CharacterSelection.PlayerCharacter;
        }
    }
}
