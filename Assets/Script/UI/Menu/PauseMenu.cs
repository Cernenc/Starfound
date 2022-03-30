using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Script.UI.Menu
{
    public class PauseMenu : MonoBehaviour
    {
        [field: SerializeField]
        public GameObject PauseMenuObject { get; set; }

        [SerializeField]
        private Button _pauseResumeBtn = null;

        [SerializeField]
        private Button _pauseOptionsBtn = null;

        [SerializeField]
        private Button _pauseMenuBtn = null;

        [field: SerializeField]
        public UnityEvent OnPauseGame { get; set; }

        void Start()
        {
            PauseMenuObject.SetActive(false);
        }

        public void PauseUnpause()
        {
            if (PauseMenuObject.activeInHierarchy)
            {
                PauseMenuObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                PauseMenuObject.SetActive(true);
                Time.timeScale = 0;

                EventSystem.current.SetSelectedGameObject(null);
                _pauseResumeBtn.Select();
                EventSystem.current.SetSelectedGameObject(_pauseResumeBtn.gameObject);
            }
        }
    }
}
