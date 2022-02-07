using Assets.Script.Core.Managers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Script.UI
{
    public class GaugeUI : MonoBehaviour
    {
        public Image GaugeImage { get; set; }

        private IGameManager gameManager { get; set; }

        private void Start()
        {
            GaugeImage = GetComponent<Image>();
        }

        [Inject]
        public void Construct(IGameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        public void Update()
        {
            if(GaugeImage.enabled == false)
            {
                return;
            }

            GaugeImage.fillAmount = (float)(gameManager.Gauge.CurrentGaugeAmount / gameManager.Gauge.MaxGaugeAmount);
        }
    }
}
