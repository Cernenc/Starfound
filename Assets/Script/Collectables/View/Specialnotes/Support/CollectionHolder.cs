using Assets.Script.Collectables.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Script.Collectables.View.Specialnotes.Support
{
    public interface ICollectionHolder
    {
        List<IMusicnote> Holder { get; set; }
    }
    public class CollectionHolder : MonoBehaviour, ICollectionHolder
    {
        public List<IMusicnote> Holder { get; set; } = new List<IMusicnote>();

        public void Start()
        {
            if (Holder != null)
            {
                Holder = new List<IMusicnote>();
            }

            Holder = GetComponentsInChildren<IMusicnote>().ToList();
        }
    }
}
