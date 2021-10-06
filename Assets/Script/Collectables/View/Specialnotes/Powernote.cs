using Assets.Script.Collectables.Controller;
using Assets.Script.Collectables.Interfaces;
using Assets.Script.Collectables.View.Specialnotes.Support;
using Assets.Script.Inventories;
using Assets.Script.PlayableCharacters.Interfaces;
using System;
using System.Collections;
using UnityEngine;
//using Zenject;

namespace Assets.Script.Collectables.View.Specialnotes
{
    public class Powernote : MonoBehaviour, IMusicnote, ISpecialnote
    {
        [field: SerializeField]
        public float FillAmount { get; private set; }

        public int SpeedCounter { get; } = 2;

        public Action OnCollect { get; set; }
        public Action OnActivation { get; set; }
        
        public IMusicnoteComponents Components { get; set; }
        public ICharacter Player { get; set; }

        public PowernoteEffect PowernoteEffect { get; set; }

        //[Inject]
        private IInventory inventory { get; set; }

        private Powernote()
        {
            MusicnoteController musicnoteController = new MusicnoteController(this);
            SpecialnoteController specialnoteController = new SpecialnoteController(this);
        }

        private void Start()
        {
            Components = GetComponent<IMusicnoteComponents>();

            PowernoteEffect = new PowernoteEffect();
            PowernoteEffect.Enemy = FindObjectOfType<EnemyHolder>();
            PowernoteEffect.Collectable = FindObjectOfType<CollectionHolder>();
        }

        public void Collect()
        {
            PowernoteEffect.Player = Player;
            inventory.AddItem(inventory.PowernoteList, this);
            OnActivation();
            HideNote();
        }

        private void HideNote()
        {
            GetComponent<MeshRenderer>().enabled = false;
        }

        public void HandleActivation()
        {
            StartCoroutine(Effect());
        }

        public IEnumerator Effect()
        {
            Time.timeScale = 0.01f;
            float pauseEndTime = Time.realtimeSinceStartup + 1;

            while(Time.realtimeSinceStartup < pauseEndTime)
            {
                yield return 0;
            }

            Time.timeScale = 1f;
            PowernoteEffect.EffectBasedOnCount(inventory.PowernoteList.Count-1);
        }

        public void AddToSpeedCounter()
        {
            Player.SpeedCounter += SpeedCounter;
        }
    }
}
