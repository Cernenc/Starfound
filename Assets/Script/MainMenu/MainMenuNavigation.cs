using System;

namespace Assets.Script.MainMenu
{
    public class MainMenuNavigation
    {
        public Action OnAxisInUse { get; set; }
        public Action OnAxisPositive { get; set; }
        public Action OnAxisNegative { get; set; }
        public Action OnConfirmSelection { get; set; }
        public Action OnGoBackInMenu { get; set; }

        private int _currentIndex = 0;
        public int CurrentIndex
        {
            get { return _currentIndex; }
            set
            {
                _currentIndex = value;
                OnAxisInUse?.Invoke();
            }
        }

        public int ArrayCount { get; set; }
        private bool _axisInUse = false;
        public void MoveOneOptionAtTime(float axisInput)
        {
            if (axisInput != 0)
            {
                if (_axisInUse == false)
                {
                    if (axisInput > 0)
                    {
                        OnAxisPositive.Invoke();
                    }
                    else
                    {
                        OnAxisNegative.Invoke();
                    }
                    _axisInUse = true;
                }
            }
            else
            {
                _axisInUse = false;
            }
        }

        public void IncreaseCurrentIndex()
        {
            CurrentIndex = (CurrentIndex + 1) % ArrayCount;
        }

        public void DecreaseCurrentIndex()
        {
            CurrentIndex--;
            if(CurrentIndex < 0)
            {
                CurrentIndex += ArrayCount;
            }
        }

        public void Confirm(bool input)
        {
            if (!input)
            {
                return;
            }

            OnConfirmSelection?.Invoke();
        }

        public void Cancel(bool input)
        {
            if (!input)
            {
                return;
            }

            OnGoBackInMenu?.Invoke();
        }
    }
}
