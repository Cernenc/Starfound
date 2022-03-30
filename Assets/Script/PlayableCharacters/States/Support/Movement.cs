using UnityEngine;

namespace Assets.Script.PlayableCharacters.States.Support
{
    public class Movement
    {
        public float Limit { private get; set; }
        public float HorizontalSpeed { private get; set; }
        public Rigidbody PlayerRigidbody { get; set; }

        public void ForceHeadwind()
        {
            float forceAmount = 0;
            
            if (Limit >= HorizontalSpeed)
            {
                forceAmount = -(Limit - HorizontalSpeed);
            }

            PlayerRigidbody.AddForce(new Vector3(forceAmount, 0));
        }
    }
}
