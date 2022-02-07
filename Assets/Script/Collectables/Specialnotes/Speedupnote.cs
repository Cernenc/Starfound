using Assets.Script.Collectables.Interfaces;
using Assets.Script.Core.Managers;
using Assets.Script.Inventories;
using Assets.Script.PlayableCharacters.Interfaces;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Assets.Script.Collectables.View.Specialnotes
{
    public class Speedupnote : MonoBehaviour, IMusicnote, ISpecialnote
    {
        [field: SerializeField]
        public float FillAmount { get; set; }
        public int SpeedCounter { get; } = 8;

        [SerializeField]
        private float _effectTimer = 0;

        [field: SerializeField]
        public UnityEvent OnCollect { get; set; }
        [field: SerializeField]
        public UnityEvent OnActivation { get; set; }

        public IMusicnoteComponents Components { get; set; }

        [Inject]
        private IInventory inventory { get; set; }

        public ICharacter Player { get; set; }

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
        }

        private void HandleCollect()
        {
            OnCollect.Invoke();
        }

        public void Collect()
        {
            MusicnoteLogic.AddNote(gameManager);
            inventory.AddItem(inventory.SpeedupnoteList, this);
        }

        public void HideItem()
        {
            this.gameObject.SetActive(false);
        }

        public IEnumerator Effect()
        {
            /*
             * Speedup note
             * increase current speed by x for y seconds
             * if over max speed => uncap max speed (glowing if happens)
             * if over max speed => contact damage to low class enemies (ant, bees), take no damage
             * go back to current speed
            */
            var temp = Player.AttributeManager.MovementSpeed;
            Player.AttributeManager.MovementSpeed *= 2;

            yield return new WaitForSeconds(_effectTimer);

            Player.AttributeManager.MovementSpeed = temp;
            HideItem();
        }

        public void HandleActivation()
        {
            CallGameObject();
            StartCoroutine(Effect());
            inventory.RemoveItem(inventory.SpeedupnoteList);
        }

        private void CallGameObject()
        {
            var temp = this.gameObject;
            temp.SetActive(true);
            temp.transform.position = Vector3.zero;
        }

        public void AddToSpeedCounter()
        {
        }
    }
}
