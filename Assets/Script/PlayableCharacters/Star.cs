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
        public ManagerDependencyInjection Manager { get; private set; }
        public ICharacterComponents Components { get; set; }
        
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

        private void Awake()
        {
            Components = GetComponent<CharacterComponents>();
        }
        private void Start()
        {
            Manager = FindObjectOfType<ManagerDependencyInjection>();
            GetStatemachine();
        }
        private void FixedUpdate()
        {
            PlayerState.ExecuteCurrentState();
        }
    }
}
