using System;

namespace Assets.Script.Core.Managers
{
    public interface IInputManager
    {
        Action<float> OnInputHorizontalMovement { get; set; }
        Action<float> OnInputVerticalMovement { get; set; }
        Action OnInputSpecial { get; set; }
        Action OnInputItem { get; set; }
        Action OnInputPause { get; set; }
        float Horizontal { get; set; }
        float Vertical { get; set; }
    }

    public class InputManager : IInputManager
    {
        public Action<float> OnInputHorizontalMovement { get; set; }
        public Action<float> OnInputVerticalMovement { get; set; }
        public Action OnInputSpecial { get; set; }
        public Action OnInputItem { get; set; }
        public Action OnInputPause { get; set; }

        private float _horizontal;
        public float Horizontal
        {
            get
            {
                return _horizontal;
            }
            set
            {
                if (_horizontal != value)
                {
                    _horizontal = value;
                    OnInputHorizontalMovement.Invoke(_horizontal);
                }
            }
        }

        private float _vertical;
        public float Vertical
        {
            get
            {
                return _vertical;
            }
            set
            {
                if (_vertical != value)
                {
                    _vertical = value;
                    OnInputVerticalMovement.Invoke(_vertical);
                }
            }
        }
    }
}
