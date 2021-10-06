using Assets.Script.Core.Managers;
using Assets.Script.PlayableCharacters.Interfaces;
using UnityEngine;

namespace Assets.Script.Cam
{
    public class CameraMovement : MonoBehaviour
    {
        public ICharacter Target { get; set; }

        public static bool CanFollow { private get; set; }
        private Vector3 _velocity = Vector3.zero;
        private const float _smoothTime = 0.25f;
        private const float _offset = 15;

        [SerializeField]
        private Collider _bottom = null;
        [SerializeField]
        private Collider _ceiling = null;
        private void Start()
        {
            Target = FindObjectOfType<PlayerManager>().Player;
        }

        private void LateUpdate()
        {
            FollowTarget();
        }

        private Vector3 TargetPos()
        {
            if(Target == null)
            {
                return Vector3.zero;
            }

            return new Vector3(Target.Components.Rigidbody.position.x + _offset,
                Mathf.Clamp(Target.Components.Rigidbody.position.y, _bottom.bounds.max.y - transform.position.y / 2, _ceiling.bounds.min.y - transform.position.y /2),
                transform.position.z);
        }

        private void FollowTarget()
        {
            var targetPos = TargetPos();
            if (CanFollow)
            {
                transform.position =
                    Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, _smoothTime);
            }
        }

        private void Restrict()
        {

        }
    }
}
