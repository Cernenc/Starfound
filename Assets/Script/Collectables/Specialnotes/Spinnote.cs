using Assets.Script.Collectables.Interfaces;
using Assets.Script.Core.Managers;
using Assets.Script.Events;
using Assets.Script.Inventories;
using Assets.Script.PlayableCharacters.Interfaces;
using Assets.Script.Timers;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Assets.Script.Collectables.View.Specialnotes
{
    public class Spinnote : MonoBehaviour, IMusicnote, ISpecialnote
    {
        [field: SerializeField]
        public double ScoreAmount { get; private set; } = 100;
        [field: SerializeField]
        public float FillAmount { get; private set; } = 10;
        [field: SerializeField]
        public int SpeedCounter { get; private set; } = 4;

        [SerializeField]
        private float _effectTimer = 0;

        public UnityEvent<double, float, int> OnCollect { get; set; }

        [field: SerializeField]
        public UnityEvent OnActivation { get; set; }

        public IMusicnoteComponents Components { get; set; }

        [Inject]
        private IInventory inventory { get; set; }

        public PlayableCharacters.Interfaces.ICharacter Player { get; set; }

        [Inject]
        private IPlayerManager PlayerManager { get; set; }

        public TimerBehaviour TimeBehaviour { get; set; }

        private void Start()
        {
            Components = GetComponent<IMusicnoteComponents>();
            //TimeBehaviour = FindObjectOfType<TimerBehaviour>();
            //TimeBehaviour.Duration = _effectTimer;
            //TimeBehaviour.TimerSetup();
        }

        public void Collect(double d, float f, int i)
        {
            inventory.AddItem(inventory.SpinnoteList, this);
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
            //Player = PlayerManager.Player;
            Player.Components.Reflector.enabled = true;
            
            yield return new WaitForSeconds(_effectTimer);
            
            Player.Components.Reflector.enabled = false;
            HideNote();
        }

        public void HideNote()
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
