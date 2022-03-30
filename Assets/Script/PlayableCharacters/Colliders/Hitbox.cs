using Assets.Script.Collectables.Interfaces;
using UnityEngine;

namespace Assets.Script.PlayableCharacters.Colliders
{
    public class Hitbox : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            var note = other.GetComponent<IMusicnote>();
            if(note != null)
            {
                note.HideNote();
            }
        }
    }
}
