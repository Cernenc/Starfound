using System;

namespace Assets.Script.PlayableCharacters.Health
{
    public interface IGauge
    {
        double MaxGaugeAmount { get; set; }
        double CurrentGaugeAmount { get; set; }
        float GaugeLossAmountPerSecond { get; set; }
        Action OnEmptyGauge { get; set; }
        void DrainGauge(float deltaTime);
        void FillGauge(float fuel);
    }
    public class Gauge : IGauge
    {
        public Action OnEmptyGauge { get; set; }
        public double MaxGaugeAmount { get; set; }
        public double CurrentGaugeAmount { get; set; }
        public float GaugeLossAmountPerSecond { get; set; }

        public void DrainGauge(float deltaTime)
        {
            CurrentGaugeAmount -= GaugeLossAmountPerSecond * deltaTime;
            CheckForEmptyGauge();
        }

        private void CheckForEmptyGauge()
        {
            if(CurrentGaugeAmount > 0)
            {
                return;
            }
            OnEmptyGauge.Invoke();
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
