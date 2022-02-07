using Assets.Script.Collectables.Interfaces;
using Assets.Script.Collectables.View.Specialnotes.Support;
using Assets.Script.Core.Managers;
using Assets.Script.Inventories;
using Assets.Script.PlayableCharacters.Interfaces;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Assets.Script.Collectables.View.Specialnotes
{
    public class Powernote : MonoBehaviour, IMusicnote, ISpecialnote
    {
        [field: SerializeField]
        public float FillAmount { get; private set; }

        public int SpeedCounter { get; } = 2;

        [field: SerializeField]
        public UnityEvent OnCollect { get; set; }
        [field: SerializeField]
        public UnityEvent OnActivation { get; set; }
        
        public IMusicnoteComponents Components { get; set; }
        public ICharacter Player { get; set; }

        public PowernoteEffect PowernoteEffect { get; set; }

        [Inject]
        private IInventory inventory { get; set; }

        public Musicnote MusicnoteLogic { get; set; }
        public IGameManager gameManager { get; set; }

        [Inject]
        public void Construct(IGameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        private void Start()
        {
            MusicnoteLogic = new Musicnote();
            MusicnoteLogic.Score = 0;
            MusicnoteLogic.SpeedCounter = SpeedCounter;
            MusicnoteLogic.FillAmount = FillAmount;
            MusicnoteLogic.OnCollect += HandleCollect;
            Components = GetComponent<IMusicnoteComponents>();

            PowernoteEffect = new PowernoteEffect();
            PowernoteEffect.Enemy = FindObjectOfType<EnemyHolder>();
            PowernoteEffect.Collectable = FindObjectOfType<CollectionHolder>();
        }

        private void HandleCollect()
        {
            OnCollect.Invoke();
        }

        public void Collect()
        {
            MusicnoteLogic.AddNote(gameManager);
            PowernoteEffect.Player = Player;
            inventory.AddItem(inventory.PowernoteList, this);
            OnActivation.Invoke();
        }

        public void HideNote()
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
        }
    }
}
