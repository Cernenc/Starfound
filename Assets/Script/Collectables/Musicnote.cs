using Assets.Script.Collectables.Interfaces;
using Assets.Script.Core.Managers;
using Assets.Script.Events;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Assets.Script.Collectables.View
{
    public class Musicnote : MonoBehaviour, IMusicnote
    {
        [field: SerializeField]
        public double ScoreAmount { get; private set; } = 50;
        [field: SerializeField]
        public float FillAmount { get; private set; } = 10;
        [field: SerializeField]
        public int SpeedCounter { get; private set; } = 3;

        public IMusicnoteComponents Components { get; set; }

        private void Start()
        {
            Components = GetComponent<IMusicnoteComponents>();
        }

        public void HideNote()
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
