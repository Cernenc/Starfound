using Assets.Script.Core.Singleton;
using Assets.Script.PlayableCharacters.Interfaces;
using System;

namespace Assets.Script.PlayableCharacters.Health
{
    public class Gauge : Singleton<Gauge>
    {
        private ICharacter Player { get; }

        public Action<ICharacter> OnEmptyGauge;

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

            OnEmptyGauge?.Invoke(Player);
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
