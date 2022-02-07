using Assets.Script.Core.Managers;
using System;

namespace Assets.Script.Collectables
{
    public class Musicnote
    {
        public Action OnCollect { get; set; }
        public int Score { get; set; }
        public float FillAmount { private get; set; }
        public int SpeedCounter { get; set; }
        
        public void AddNote(IGameManager gameManager)
        {
            AddToScore(gameManager);
            FillGauge(gameManager);
            AddToCounter(gameManager);
            OnCollect?.Invoke();
        }

        private void AddToScore(IGameManager gameManager)
        {
            gameManager.Score += Score;
        }

        private void FillGauge(IGameManager gameManager)
        {
            gameManager.Gauge.FillGauge(FillAmount);
        }

        private void AddToCounter(IGameManager gameManager)
        {
            gameManager.SpeedCounter += SpeedCounter;
        }
    }
}
