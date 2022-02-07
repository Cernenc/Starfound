using System.Collections;
using UnityEngine.Events;

namespace Assets.Script.Collectables.Interfaces
{
    public interface ISpecialnote
    {
        UnityEvent OnActivation { get; set; }
        void HandleActivation();
        IEnumerator Effect();
    }
}
