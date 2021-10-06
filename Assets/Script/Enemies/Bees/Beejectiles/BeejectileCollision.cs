using Assets.Script.PlayableCharacters.Interfaces;
using UnityEngine;

namespace Assets.Script.Enemies.Bees.Beejectiles
{
    public class BeejectileCollision : MonoBehaviour
    {
        public void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.GetComponent<ICharacter>() != null)
            {
                GetComponent<Beejectile>().DestroyProjectile();
            }
        }
    }
}
