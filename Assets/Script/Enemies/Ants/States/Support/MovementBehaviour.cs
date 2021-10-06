using UnityEngine;

namespace Assets.Script.Enemies.Ants.States.Support
{
    public class MovementBehaviour
    {
        public void CanTurn(bool[] conditions)
        {
            int i = 0;
            foreach(var condition in conditions)
            {
                if (condition)
                {
                    i++;
                }
            }

            if(i == conditions.Length)
            {
                Turn();
            }
        }

        private Vector3 Turn()
        {
            return new Vector3(0, 180, 0);
        }
    }
}
