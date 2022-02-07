using Assets.Script.PlayableCharacters.Interfaces;
using UnityEngine.Events;

namespace Assets.Script.Collectables.Interfaces
{
    public interface IMusicnote
    {
        float FillAmount { get; }
        UnityEvent OnCollect { get; set; }
        IMusicnoteComponents Components { get; set; }
        void Collect();
        ICharacter Player { get; set; }
    }
}