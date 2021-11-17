using Assets.Script.PlayableCharacters.Interfaces;

namespace Assets.Script.Collectables.Model
{
    public interface IMusicnoteModel
    {
        void FillGauge(float fillAmount, ICharacter player);
    }

    public class MusicnoteModel : IMusicnoteModel
    {
        public void FillGauge(float fillAmount, ICharacter player)
        {
            player.PlayerGauge.FillGauge(fillAmount);
        }
    }
}
