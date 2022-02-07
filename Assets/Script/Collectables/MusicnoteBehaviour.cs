using Assets.Script.Collectables.Interfaces;
using Assets.Script.Core.Managers;
using Assets.Script.PlayableCharacters.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Assets.Script.Collectables.View
{
    public class MusicnoteBehaviour : MonoBehaviour, IMusicnote
    {
        [field: SerializeField]
        public float FillAmount { get; set; } = 10;
        public int SpeedCounter { get; } = 3;

        [field: SerializeField]
        public UnityEvent OnCollect { get; set; }

        public IMusicnoteComponents Components { get; set; }

        public Musicnote MusicnoteLogic { get; set; }

        public ICharacter Player { get; set; }

        private IGameManager gameManager { get; set; }

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
        }

        public void HideNote()
        {
            this.gameObject.SetActive(false);
        }
    }
}
