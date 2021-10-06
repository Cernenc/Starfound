using Assets.Script.PlayableCharacters.Interfaces;
using UnityEngine;

namespace Assets.Script.PlayableCharacters.States.Support
{
    public class StartingPoint : MonoBehaviour
    {
        private Vector3 MoveTowardsStart(Vector3 playerPosition, Vector2 startPos)
        {
            return Vector3.MoveTowards(playerPosition, startPos, 5 * Time.deltaTime);
        }

        public Vector3 AtStartPosition(Vector3 target, ICharacter character)
        {
            Vector2 targetPos = new Vector2(target.x, target.y);
            Vector2 startPos = new Vector2(transform.position.x, transform.position.y);
            if (Vector3.Distance(targetPos, startPos) < float.Epsilon)
            {
                character.ChangeState(FlyingState.Instance);
            }

            return MoveTowardsStart(targetPos, startPos);
        }
    }
}
