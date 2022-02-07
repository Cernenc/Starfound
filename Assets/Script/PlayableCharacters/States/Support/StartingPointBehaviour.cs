using Assets.Script.PlayableCharacters.Interfaces;
using UnityEngine;

namespace Assets.Script.PlayableCharacters.States.Support
{
    public class StartingPointBehaviour : MonoBehaviour
    {
        public Vector2 StartPos { get; set; }

        public Vector3 MoveTowardsStart(Vector2 playerPosition, ICharacter character)
        {
            if (AtStartPosition(playerPosition))
            {
                character.ChangeState(FlyingState.Instance);
            }

            return Vector3.MoveTowards(playerPosition, StartPos, character.AttributeManager.FallBackSpeed * Time.deltaTime);
        }

        public bool AtStartPosition(Vector2 playerPosition)
        {
            StartPos = new Vector2(transform.position.x, transform.position.y);
            return Vector3.Distance(playerPosition, StartPos) < float.Epsilon;
        }
    }
}
