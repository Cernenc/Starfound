using UnityEngine.Events;

namespace Assets.Script.Collectables.Interfaces
{
    public interface IMusicnote
    {
        double ScoreAmount { get; }
        float FillAmount { get; }
        int SpeedCounter { get; }
        IMusicnoteComponents Components { get; set; }
        void HideNote();
    }
}