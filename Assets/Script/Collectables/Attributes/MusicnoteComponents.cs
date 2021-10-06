using Assets.Script.Collectables.Interfaces;
using UnityEngine;

namespace Assets.Script.Collectables.Attributes
{
    public class MusicnoteComponents : MonoBehaviour, IMusicnoteComponents
    {
        public Transform Transform => GetComponent<Transform>();
    }
}
