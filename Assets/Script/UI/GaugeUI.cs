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
            if(GaugeImage.enabled == false)
            {
                //Debug.Log((int)Gauge.Instance.CurrentGaugeAmount / Gauge.Instance.MaxGaugeAmount);
                return;
            }

            GaugeImage.fillAmount = (float)(Gauge.Instance.CurrentGaugeAmount / Gauge.Instance.MaxGaugeAmount);
        }
    }
}
