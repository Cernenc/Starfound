using Assets.Script.PlayableCharacters.States;
using Assets.Script.PlayableCharacters.Attributes;
using Assets.Script.PlayableCharacters.Interfaces;
using Assets.Script.Statemachine;
using Assets.Script.Statemachine.Interfaces;
using UnityEngine;
using Assets.Script.Core.Managers;

namespace Assets.Script.PlayableCharacters
{
    public class Star : MonoBehaviour, ICharacter
    {
        public ICharacterComponents Components { get; set; }
        public PlayerManager playerManager { get; set; }
        public AnimationManager animationManager { get; set; }

        public int SpeedCounter { get; set; } = 0;

        [SerializeField]
        private CharacterAttributeManager _attributeManager = null;
        public ICharacterAttributeManager AttributeManager
        {
            get => _attributeManager;
        }

        private Statemachine<IEnterExecuteExit<ICharacter>, ICharacter> PlayerState { get; set; }

        private void GetStatemachine()
        {
            PlayerState = new Statemachine<IEnterExecuteExit<ICharacter>, ICharacter>();
            PlayerState.CurrentCharacter = this;
            ChangeState(PreStartState.Instance);
        }

        public void ChangeState(IEnterExecuteExit<ICharacter> newState)
        {
            PlayerState.ChangeState(newState);
        }

        private void Start()
        {         
            Components = GetComponent<CharacterComponents>();
            playerManager = FindObjectOfType<PlayerManager>();
            playerManager.Player = this;
            animationManager = FindObjectOfType<AnimationManager>();
            GetStatemachine();
        }

        private void FixedUpdate()
        {
            PlayerState.ExecuteCurrentState();
        }
    }
}
