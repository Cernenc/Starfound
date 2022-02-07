using UnityEngine;

namespace Assets.Script.Support
{
    public class EnvironmentCheck
    {
        public Collider[] CheckForSurroundingGround(Collider collider, LayerMask checkForEnvironmentLayer)
        {

            Collider[] allCollidersNearby = Physics.OverlapBox(collider.bounds.center, collider.bounds.size / 2, Quaternion.identity, checkForEnvironmentLayer);

            return allCollidersNearby;
        }
    }
}
