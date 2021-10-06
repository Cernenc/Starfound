using Assets.Script.PlayableCharacters.Interfaces;
using System;

namespace Assets.Script.Collectables.Interfaces
{
    public interface IMusicnote
    {
        float FillAmount { get; }
        Action OnCollect { get; set; }
        IMusicnoteComponents Components { get; set; }
        void Collect();
        void AddToSpeedCounter();

        ICharacter Player { get; set; }
    }
}