using Assets.Script.Core.Managers;
using Assets.Script.PlayableCharacters.Attributes;
using Assets.Script.Statemachine.Interfaces;

namespace Assets.Script.PlayableCharacters.Interfaces
{
    public interface ICharacter
    {
        ICharacterAttributeManager AttributeManager { get; }
        ICharacterComponents Components { get; }
        void ChangeState(IEnterExecuteExit<ICharacter> newState);
        int SpeedCounter { get; set; }
        PlayerManager playerManager { get; set; }
        AnimationManager animationManager { get; set; }
    }
}
