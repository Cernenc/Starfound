using Assets.Script.Core.Managers;
using Assets.Script.PlayableCharacters.Interfaces;
using Assets.Script.Scenes;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Script.CharacterSelections
{
    public class CharacterSelection : MonoBehaviour
    {
        [field: SerializeField]
        public List<Button> PlayableCharacters { get; set; }

        private Action<GameObject> OnSelected { get; set; }

        void Start()
        {
            OnSelected += HandlePlayer;
            EventSystem.current.SetSelectedGameObject(null);
            PlayableCharacters[0].Select();
            EventSystem.current.SetSelectedGameObject(PlayableCharacters[0].gameObject);
        }

        public void OnSelection()
        {
            var selection = EventSystem.current.currentSelectedGameObject.GetComponent<CharacterSelectionModel>().CharacterHolder;
            Loader loader = new Loader();
            //StartCoroutine(loader.LoadLevelAsync(OnSelected);


        }

        public void HandlePlayer(GameObject selection)
        {
            FindObjectOfType<PlayerManager>().Player = selection.GetComponent<CharacterSelectionModel>().CharacterHolder.GetComponent<ICharacter>();
        }
    }
}
