using Assets.Script.PlayableCharacters.Interfaces;
using System;

namespace Assets.Script.PlayableCharacters.Health
{
    public class Gauge
    {
        public ICharacter Player { get; set; }
        public Action<Action> OnEmptyGauge { get; set; }
        private double _max;
        public double MaxGaugeAmount
        {
            get => _max;
            set
            {
                _max = value;
                if (CurrentGaugeAmount == 0)
                {
                    CurrentGaugeAmount = _max;
                }
            }
        }

        public double CurrentGaugeAmount { get; set; }

        public void DrainGauge(float gaugeLossAmountPerSecond)
        {
            CurrentGaugeAmount -= gaugeLossAmountPerSecond;
            CheckForEmptyGauge();
        }

        private void CheckForEmptyGauge()
        {
            if(CurrentGaugeAmount > 0)
            {
                return;
            }
            OnEmptyGauge(() => Player.playerManager.OnDeath());
        }

        public void FillGauge(float fuel)
        {
            CurrentGaugeAmount += fuel;
            LimitGaugeAmount();
        }

        public void LoseGaugeByAmount(float damage)
        {
            CurrentGaugeAmount -= damage;
        }

        private void LimitGaugeAmount()
        {
            if (CurrentGaugeAmount > MaxGaugeAmount)
            {
                CurrentGaugeAmount = MaxGaugeAmount;
            }
        }
    }
}
