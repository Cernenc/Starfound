using System;
using System.Collections;

namespace Assets.Script.Collectables.Interfaces
{
    public interface ISpecialnote
    {
        Action OnActivation { get; set; }
        void HandleActivation();
        IEnumerator Effect();
    }
}
