using Assets.Script.Enemies.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Script.Collectables.View.Specialnotes.Support
{
    public interface IEnemyHolder
    {
        List<IEnemy> Holder { get; set; }
    }
    public class EnemyHolder : MonoBehaviour, IEnemyHolder
    {
        public List<IEnemy> Holder { get; set; } = new List<IEnemy>();

        public void Start()
        {
            if (Holder != null)
            {
                Holder = new List<IEnemy>();
            }

            Holder = GetComponentsInChildren<IEnemy>().ToList();
        }
    }
}
