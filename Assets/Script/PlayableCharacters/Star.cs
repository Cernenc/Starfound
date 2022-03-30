using Assets.Script.PlayableCharacters.States;
using Assets.Script.PlayableCharacters.Attributes;
using Assets.Script.PlayableCharacters.Interfaces;
using Assets.Script.Statemachine;
using Assets.Script.Statemachine.Interfaces;
using UnityEngine;
using Assets.Script.PlayableCharacters.States.Support;
using UnityEngine.Events;

namespace Assets.Script.PlayableCharacters
{
    public class Star : MonoBehaviour, ICharacter
    {
        public ICharacterComponents Components { get; set; }
        
        [SerializeField]
        private CharacterAttributeManager _attributeManager = null;
        public ICharacterAttributeManager AttributeManager
        {
            get => _attributeManager;
        }

        public int SpeedCounter { get; set; }
        public float Horizontal { get; set; } = 1;
        public float Vertical { get; set; }
        public bool IsInvincible { get; set; }

        public StartingPointBehaviour StartingPoint { get; set; }

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
            GetStatemachine();
        }

        private void FixedUpdate()
        {
            PlayerState.ExecuteCurrentState();
        }
    }
}
