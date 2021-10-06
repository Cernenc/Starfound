using Assets.Script.PlayableCharacters.Health;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.UI
{
    public class GaugeUI : MonoBehaviour
    {
        public Image GaugeImage { get; set; }

        private void Start()
        {
            GaugeImage = GetComponent<Image>();
        }

        public void Update()
        {
            GaugeImage.fillAmount = (float)(Gauge.Instance.CurrentGaugeAmount / Gauge.Instance.MaxGaugeAmount);
        }
    }
}
