using Assets.Script.MainMenu;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Script.LevelSelection
{
    public class GameStartEvent : UnityEvent<GameObject>
    {
        public GameObject Level { get; set; }
    }

    public class LevelSelect : MonoBehaviour
    {
        public GameStartEvent OnStartGame { get; set; }
        [field: SerializeField]
        public GameObject CharacterSelectObject { get; set; }

        [field: SerializeField]
        public Transform CharacterIcon { get; set; }

        [field: SerializeField]
        public Transform LevelParentPrefab { get; set; }

        [field: SerializeField]
        public Level[] AllLevels { get; set; }

        private MainMenuNavigation Navigation { get; set; }

        private List<GameObject> LevelInstances = new List<GameObject>();

        [field: SerializeField]
        private Transform LevelPreviewParent = default;

        public void Start()
        {
            FillList();
            Navigation = new MainMenuNavigation();
            Navigation.ArrayCount = LevelInstances.Count;
            Navigation.OnAxisInUse += HandleMoveArrow;
            Navigation.OnAxisPositive += HandleMoveRight;
            Navigation.OnAxisNegative += HandleMoveLeft;
            Navigation.OnConfirmSelection += HandleConfirm;
            Navigation.OnGoBackInMenu += HandleGoBack;
            Navigation.CurrentIndex = 0;
        }

        private void FillList()
        {
            foreach(var level in AllLevels)
            {
                GameObject levelInstance =
                    Instantiate(level.LevelPreviewPrefab, LevelPreviewParent);

                LevelInstances.Add(levelInstance);
            }
        }

        private void HandleMoveArrow()
        {
            if (Navigation.CurrentIndex < 0)
            {
                return;
            }

            CharacterIcon.position = new Vector3(LevelInstances[Navigation.CurrentIndex].transform.position.x, CharacterIcon.position.y, 0);
        }

        private void HandleGoBack()
        {
            CharacterSelectObject.SetActive(true);
            this.gameObject.SetActive(false);
        }

        private void HandleConfirm()
        {
            OnStartGame.Level = AllLevels[Navigation.CurrentIndex].LevelGameplayPrefab;
            OnStartGame.Invoke(OnStartGame.Level);
            this.gameObject.SetActive(false);
        }

        private void HandleMoveLeft()
        {
            Navigation.DecreaseCurrentIndex();
        }

        private void HandleMoveRight()
        {
            Navigation.IncreaseCurrentIndex();
        }

        private void Update()
        {
            Navigation.MoveOneOptionAtTime(Input.GetAxisRaw("Horizontal"));
            Navigation.Confirm(Input.GetButtonDown("Jump"));
            Navigation.Cancel(Input.GetButtonDown("Cancel"));
        }
    }
}
