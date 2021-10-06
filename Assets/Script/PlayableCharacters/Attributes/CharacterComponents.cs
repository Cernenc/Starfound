using Assets.Script.PlayableCharacters.Interfaces;
using UnityEngine;

namespace Assets.Script.PlayableCharacters.Attributes
{
    public class CharacterComponents : MonoBehaviour, ICharacterComponents
    {
        public Rigidbody Rigidbody 
        {
            get => GetComponent<Rigidbody>();
        }

        [field: SerializeField]
        public Collider Hurtbox { get; set; }

        [field: SerializeField]
        public Collider Reflector { get; set; }

        public Animator PlayerAnimator => GetComponent<Animator>();
    }
}
