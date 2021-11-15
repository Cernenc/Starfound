using Assets.Script.Enemies.Ants;
using Assets.Script.Enemies.Ants.States;
using Assets.Script.Enemies.Bees;
using Assets.Script.Enemies.Bees.States;
using Assets.Script.Enemies.Interfaces;
using Assets.Script.PlayableCharacters.Colliders;
using Assets.Script.PlayableCharacters.Interfaces;
using UnityEngine;


namespace Assets.Script.Enemies.Triggers
{
    /// <summary>
    /// separate classes or one?
    /// </summary>
    public class TriggerRange : MonoBehaviour
    {
        public IEnemy Enemy { get; set; }

        public void Awake()
        {
            Enemy = this.GetComponentInParent<IEnemy>();
        }

        public void OnTriggerEnter(Collider other)
        {
            //other.getcomponentinparent<ICharacter>() triggers three times -> hit-, hurtbox and body
            if (other.GetComponent<Hurtbox>() != null)
            {
                GetEnraged();
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Hurtbox>() != null)
            {
                GetNormal();
            }
        }

        private void GetEnraged()
        {
            if (Enemy.GetType() == typeof(Ant))
            {
                Enemy.ChangeState(AntEnragedState.Instance);
            }
            if (Enemy.GetType() == typeof(BeeHive))
            {
                 Enemy.ChangeState(BeeEnragedState.Instance);
            }
        }

        private void GetNormal()
        {
            if (Enemy.GetType() == typeof(Ant))
            {
                Enemy.ChangeState(AntDefaultState.Instance);
            }
        }
    }
}
