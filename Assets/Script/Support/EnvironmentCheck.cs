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

        public bool IsGrounded(Collider collider, LayerMask checkForEnvironmentLayer)
        {
            //bool raycastHit = Physics.BoxCast(collider.bounds.center, collider.bounds.extents, Vector2.down, out hit, collider.transform.rotation, 5f);
            var raycastHit = Physics.Raycast(new Vector3(collider.bounds.extents.x + 1, collider.bounds.center.y), Vector3.down, 1f, checkForEnvironmentLayer);
            return raycastHit;
        }
    }
}
