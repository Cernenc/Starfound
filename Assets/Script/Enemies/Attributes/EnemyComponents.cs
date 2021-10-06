using Assets.Script.Enemies.Interfaces;
using UnityEngine;

namespace Assets.Script.Enemies.Attributes
{
    public class EnemyComponents : MonoBehaviour, IEnemyComponents
    {
        public Transform Transform
        {
            get => GetComponent<Transform>();
        }

        public Collider Collider
        {
            get => GetComponent<Collider>();
        }
    }
}
