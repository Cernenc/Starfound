using UnityEngine;
using UnityEngine.Events;

namespace Assets.Script.Timers
{
    public class TimerBehaviour : MonoBehaviour
    {
        [field: SerializeField]
        public float Duration = 2f;

        public UnityEvent OnTimerEnd { get; set; } = null;

        private Timer _timer = null;

        private void Start()
        {
            TimerSetup();
        }

        public void TimerSetup(UnityAction action = null)
        {
            _timer = new Timer();
            _timer.RemainingSeconds = Duration;
            _timer.OnTimerEnd += HandleTimerEnd;
            OnTimerEnd = new UnityEvent();
            OnTimerEnd.RemoveAllListeners();
            OnTimerEnd.AddListener(action);
        }

        public void RemoveListeners()
        {
            OnTimerEnd.RemoveAllListeners();
        }

        private void HandleTimerEnd()
        {
            OnTimerEnd.Invoke();
        }

        //private void Update()
        //{
        //    if (TimerIsStarting)
        //    {
        //        _timer.Tick(Time.deltaTime);
        //        ShowTimer();
        //    }
        //}
    }
}
