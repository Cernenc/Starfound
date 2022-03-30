using Assets.Script.MainMenu;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Script.CharacterSelection
{
    public class CharacterSelect : MonoBehaviour
    {
        public UnityEvent OnSelectCharacter { get; set; }
        public GameObject PlayerCharacter { get; set; }
        
        [field:SerializeField]
        public GameObject MainMenuPrefab { get; set; }

        [field: SerializeField]
        public GameObject LevelSelectionPrefab { get; set; }

        [SerializeField] private GameObject _characterSelectDisplay = default;
        [SerializeField] private Transform _characterPreviewParent = default;
        [SerializeField] private TMP_Text _characterNameText = default;
        [SerializeField] private Character[] _characters = default;

        private readonly List<GameObject> _characterInstances = new List<GameObject>();

        private MainMenuNavigation Navigation { get; set; }

        private void Start()
        {
            Navigation = new MainMenuNavigation();
            InstantiateCharacters();
            Navigation.OnAxisPositive += HandleMoveRight;
            Navigation.OnAxisNegative += HandleMoveLeft;
            Navigation.OnConfirmSelection += HandleConfirm;
            Navigation.OnGoBackInMenu += HandleGoBack;
            Navigation.ArrayCount = _characterInstances.Count;
        }

        private void Update()
        {
            Navigation.MoveOneOptionAtTime(Input.GetAxisRaw("Horizontal"));
            Navigation.Confirm(Input.GetButtonDown("Jump"));
            Navigation.Cancel(Input.GetButtonDown("Cancel"));
        }

        private void HandleConfirm()
        {
            PlayerCharacter = _characters[Navigation.CurrentIndex].CharacterGameplayPrefab;
            LevelSelectionPrefab.SetActive(true);
            OnSelectCharacter?.Invoke();
            this.gameObject.SetActive(false);
        }

        private void HandleGoBack()
        {
            MainMenuPrefab.SetActive(true);
            this.gameObject.SetActive(false);
        }

        private void HandleMoveRight()
        {
            _characterInstances[Navigation.CurrentIndex].SetActive(false);
            Navigation.IncreaseCurrentIndex();
            _characterInstances[Navigation.CurrentIndex].SetActive(true);
            _characterNameText.text = _characters[Navigation.CurrentIndex].CharacterName;
        }
        private void HandleMoveLeft()
        {
            _characterInstances[Navigation.CurrentIndex].SetActive(false);
            Navigation.DecreaseCurrentIndex();
            _characterInstances[Navigation.CurrentIndex].SetActive(true);
            _characterNameText.text = _characters[Navigation.CurrentIndex].CharacterName;
        }

        private void InstantiateCharacters()
        {
            foreach (var character in _characters)
            {
                GameObject characterInstance =
                    Instantiate(character.CharacterPreviewPrefab, _characterPreviewParent);

                characterInstance.SetActive(false);

                _characterInstances.Add(characterInstance);
            }

            _characterInstances[Navigation.CurrentIndex].SetActive(true);
            _characterNameText.text = _characters[Navigation.CurrentIndex].CharacterName;

            _characterSelectDisplay.SetActive(true);
        }
    }
}
