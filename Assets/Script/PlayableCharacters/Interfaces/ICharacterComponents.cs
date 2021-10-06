using UnityEngine;

namespace Assets.Script.PlayableCharacters.Interfaces
{
    public interface ICharacterComponents
    {
        Rigidbody Rigidbody { get; }
        Collider Hurtbox { get; }
        Collider Reflector { get; }
        Animator PlayerAnimator { get; }
    }
}
