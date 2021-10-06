using Assets.Script.Collectables.Controller;
using Assets.Script.Collectables.Interfaces;
using Assets.Script.PlayableCharacters.Interfaces;
using System;
using UnityEngine;

namespace Assets.Script.Collectables.View
{
    public class Musicnote : MonoBehaviour, IMusicnote
    {
        [field: SerializeField]
        public float FillAmount { get; set; } = 0;

        public int SpeedCounter { get; } = 3;

        public Action OnCollect { get; set; }

        public IMusicnoteComponents Components { get; set; }

        public ICharacter Player { get; set; }

        private Musicnote()
        {
            MusicnoteController controller = new MusicnoteController(this);
        }

        private void Start()
        {
            Components = GetComponent<IMusicnoteComponents>();
        }

        public void Collect()
        {
            HideNote();
        }

        private void HideNote()
        {
            this.gameObject.SetActive(false);
        }

        public void AddToSpeedCounter()
        {
            Player.SpeedCounter += SpeedCounter;
        }
    }
}
