using Assets.Script.PlayableCharacters.Health;

namespace Assets.Script.Collectables.Model
{
    public interface IMusicnoteModel
    {
        void FillGauge(float fillAmount);
    }

    public class MusicnoteModel : IMusicnoteModel
    {
        public void FillGauge(float fillAmount)
        {
            Gauge.Instance.FillGauge(fillAmount);
        }
    }
}
