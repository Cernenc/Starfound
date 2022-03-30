using System;
using UnityEngine;

namespace Assets.Script.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Transform _arrow = default;

        [SerializeField]
        private Transform[] _mainMenuSelections = default;

        private MainMenuNavigation Navigation { get; set; }

        [field: SerializeField]
        public GameObject CharacterSelectionPrefab { get; set; }

        private void Awake()
        {
            CharacterSelectionPrefab.SetActive(false);
        }

        private void Start()
        {
            Navigation = new MainMenuNavigation();
            Navigation.OnAxisInUse += HandleMoveArrow;
            Navigation.OnAxisPositive += HandleAxisMoveUp;
            Navigation.OnAxisNegative += HandleAxisMoveDown;
            Navigation.OnConfirmSelection += HandleConfirm;
            Navigation.OnGoBackInMenu += HandleGoBack;
            Navigation.CurrentIndex = 0;
            Navigation.ArrayCount = _mainMenuSelections.Length;
        }

        private void HandleGoBack()
        {
            QuitGame();
        }

        private void HandleConfirm()
        {
            switch (Navigation.CurrentIndex)
            {
                case 0:
                    OpenCharacterSelection();
                    break;
                case 1:
                    OpenOptionsSelection();
                    break;
                case 2:
                    QuitGame();
                    break;
                default:
                    break;
            }

            this.gameObject.SetActive(false);
        }

        private void QuitGame()
        {
            Debug.Log("QUIT");
        }

        private void OpenOptionsSelection()
        {
            throw new NotImplementedException();
        }

        private void OpenCharacterSelection()
        {
            CharacterSelectionPrefab.SetActive(true);
        }

        private void HandleAxisMoveDown()
        {
            Navigation.IncreaseCurrentIndex();
        }

        private void HandleAxisMoveUp()
        {
            Navigation.DecreaseCurrentIndex();
        }

        private void HandleMoveArrow()
        {
            if(Navigation.CurrentIndex < 0)
            {
                return;
            }
            _arrow.position = new Vector3(_arrow.position.x, _mainMenuSelections[Navigation.CurrentIndex].position.y, 0);
        }

        private void Update()
        {
            Navigation.MoveOneOptionAtTime(Input.GetAxisRaw("Vertical"));
            Navigation.Confirm(Input.GetButtonDown("Jump"));
            Navigation.Cancel(Input.GetButtonDown("Cancel"));
        }
    }
}
