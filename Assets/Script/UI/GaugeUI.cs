using Assets.Script.Core.Managers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Script.UI
{
    public class GaugeUI : MonoBehaviour
    {
        public Image GaugeImage { get; set; }

        [Inject]
        private IPlayerManager playerManager { get; set; }

        private void Start()
        {
            GaugeImage = GetComponent<Image>();
        }

        public void Update()
        {
            if(GaugeImage.enabled == false)
            {
                return;
            }

            //GaugeImage.fillAmount = (float)(playerManager.PlayerGauge.CurrentGaugeAmount / playerManager.PlayerGauge.MaxGaugeAmount);
        }
    }
}
