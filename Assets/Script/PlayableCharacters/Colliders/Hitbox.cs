using Assets.Script.Collectables.Interfaces;
using Assets.Script.PlayableCharacters.Interfaces;
using UnityEngine;

namespace Assets.Script.PlayableCharacters.Colliders
{
    public class Hitbox : MonoBehaviour
    {
        private ICharacter _player;

        private void Start()
        {
            _player = GetComponentInParent<ICharacter>();
        }

        public void OnTriggerEnter(Collider other)
        {
            var note = other.GetComponent<IMusicnote>();
            if(note != null)
            {
                note.Player = _player;
                note.Collect();
            }
        }
    }
}
