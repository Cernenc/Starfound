using Assets.Script.Collectables.Controller;
using Assets.Script.Collectables.Interfaces;
using Assets.Script.Inventories;
using Assets.Script.PlayableCharacters.Interfaces;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Script.Collectables.View.Specialnotes
{
    public class Spinnote : MonoBehaviour, IMusicnote, ISpecialnote
    {
        [field: SerializeField]
        public float FillAmount { get; set; }
        public int SpeedCounter { get; } = 4;

        [SerializeField]
        private float _effectTimer = 0;

        public Action OnCollect { get; set; }
        public Action OnActivation { get; set; }

        public IMusicnoteComponents Components { get; set; }

        [Inject]
        private IInventory inventory { get; set; }

        public ICharacter Player { get; set; }

        private Spinnote()
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
            inventory.AddItem(inventory.SpinnoteList, this);
            HideItem();
        }

        private void HideItem()
        {
            this.gameObject.SetActive(false);
        }

        public void HandleActivation()
        {
            CallGameObject();
            StartCoroutine(Effect());
            inventory.RemoveItem(inventory.SpinnoteList);
        }

        private void CallGameObject()
        {
            if(this.gameObject.activeInHierarchy)
            {
                return;
            }
            var temp = this.gameObject;
            temp.SetActive(true);
            temp.transform.position = Vector3.zero;
        }

        public IEnumerator Effect()
        {
            /* 
             * Spin note
             * activate reflect collider
             * any projectile hitting or already inside the collider get bounced back
             * holds for y seconds
             */
            Player.Components.Reflector.enabled = true;
            
            yield return new WaitForSeconds(_effectTimer);
            
            Player.Components.Reflector.enabled = false;
            HideItem();
        }

        public void AddToSpeedCounter()
        {
            Player.SpeedCounter += SpeedCounter;
        }
    }
}
