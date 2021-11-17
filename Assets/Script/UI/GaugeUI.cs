using Assets.Script.Core.Managers;
using Assets.Script.PlayableCharacters.Health;
using Assets.Script.PlayableCharacters.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.UI
{
    public class GaugeUI : MonoBehaviour
    {
        public Image GaugeImage { get; set; }
        ICharacter Player { get; set; }

        private void Start()
        {
            GaugeImage = GetComponent<Image>();
            Player = FindObjectOfType<PlayerManager>().Player;
        }

        public void Update()
        {
            if(GaugeImage.enabled == false)
            {
                return;
            }

            GaugeImage.fillAmount = (float)(Player.PlayerGauge.CurrentGaugeAmount / Player.PlayerGauge.MaxGaugeAmount);
        }
    }
}
