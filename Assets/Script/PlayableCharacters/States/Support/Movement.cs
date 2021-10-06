using Assets.Script.PlayableCharacters.Interfaces;
using UnityEngine;

namespace Assets.Script.PlayableCharacters.States.Support
{
    public class Movement
    {
        public ICharacter Character { private get; set; }
        public static float VerticalMovement { get; set; } = 0;
        public void ForceMovement(float horizontalMovement)
        {
            Character.Components.Rigidbody.AddForce(new Vector3(horizontalMovement, VerticalMovement));
        }

        public void ForceHeadwind(float limit)
        {
            float forceAmount = 0;
            float movementSpeed = Character.AttributeManager.MovementSpeed;
            if (limit >= movementSpeed)
            {
                forceAmount = -(limit - movementSpeed);
            }

            Character.Components.Rigidbody.AddForce(new Vector3(forceAmount, 0));
        }
    }
}
