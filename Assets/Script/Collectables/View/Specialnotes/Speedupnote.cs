using Assets.Script.Collectables.Controller;
using Assets.Script.Collectables.Interfaces;
using Assets.Script.Inventories;
using Assets.Script.PlayableCharacters.Interfaces;
using System;
using System.Collections;
using UnityEngine;
//using Zenject;

namespace Assets.Script.Collectables.View.Specialnotes
{
    public class Speedupnote : MonoBehaviour, IMusicnote, ISpecialnote
    {
        [field: SerializeField]
        public float FillAmount { get; set; }

        public int SpeedCounter { get; } = 8;

        [SerializeField]
        private float _effectTimer = 0;

        public Action OnCollect { get; set; }
        public Action OnActivation { get; set; }

        public IMusicnoteComponents Components { get; set; }

        //[Inject]
        private IInventory inventory { get; set; }

        public ICharacter Player { get; set; }

        private Speedupnote()
        {
            MusicnoteController controller = new MusicnoteController(this);
            SpecialnoteController specialnoteController = new SpecialnoteController(this);
        }

        private void Start()
        {
            Components = GetComponent<IMusicnoteComponents>();
        }

        public void Collect()
        {
            inventory.AddItem(inventory.SpeedupnoteList, this);
            HideItem();
        }

        private void HideItem()
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
            Player.SpeedCounter += SpeedCounter;
        }
    }
}
