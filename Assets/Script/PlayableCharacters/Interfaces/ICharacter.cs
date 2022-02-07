using Assets.Script.Core.Managers;
using Assets.Script.PlayableCharacters.Attributes;
using Assets.Script.Statemachine.Interfaces;

namespace Assets.Script.PlayableCharacters.Interfaces
{
    public interface ICharacter
    {
        ManagerDependencyInjection Manager { get; }
        ICharacterAttributeManager AttributeManager { get; }
        ICharacterComponents Components { get; }
        void ChangeState(IEnterExecuteExit<ICharacter> newState);
    }
}
