using Assets.Script.Collectables.Interfaces;
using Assets.Script.Core.Managers;
using Assets.Script.Events;
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
        public double ScoreAmount { get; private set; } = 100;
        [field: SerializeField]
        public float FillAmount { get; private set; } = 10;
        [field: SerializeField]
        public int SpeedCounter { get; private set; } = 4;

        [SerializeField]
        private float _effectTimer = 0;

        [field: SerializeField]
        public UnityEvent OnActivation { get; set; }

        public IMusicnoteComponents Components { get; set; }

        [Inject]
        private IInventory inventory { get; set; }

        public PlayableCharacters.Interfaces.ICharacter Player { get; set; }

        [Inject]
        private IPlayerManager PlayerManager { get; set; }

        private void Start()
        {
            Components = GetComponent<IMusicnoteComponents>();
        }

        public void Collect(double d, float f, int i)
        {
            inventory.AddItem(inventory.SpeedupnoteList, this);
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

            //Player = PlayerManager.Player;
            var temp = Player.AttributeManager.BaseSpeed;
            Player.AttributeManager.BaseSpeed *= 2;

            yield return new WaitForSeconds(_effectTimer);

            Player.AttributeManager.BaseSpeed = temp;
            HideNote();
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

        public void HideNote()
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
