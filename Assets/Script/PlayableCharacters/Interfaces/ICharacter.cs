using Assets.Script.PlayableCharacters.Attributes;
using Assets.Script.PlayableCharacters.States.Support;
using Assets.Script.Statemachine.Interfaces;
using UnityEngine.Events;
using Zenject;

namespace Assets.Script.PlayableCharacters.Interfaces
{
    public interface ICharacter
    {
        ICharacterAttributeManager AttributeManager { get; }
        ICharacterComponents Components { get; }
        StartingPointBehaviour StartingPoint { get; set; }
        void ChangeState(IEnterExecuteExit<ICharacter> newState);
        int SpeedCounter { get; set; }
        float Horizontal { get;  set; }
        float Vertical { get;  set; }
        bool IsInvincible { get; set; }
    }

    public class Factory : PlaceholderFactory<ICharacter> { }
}
