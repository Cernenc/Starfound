using Assets.Script.PlayableCharacters.Interfaces;
using Assets.Script.PlayableCharacters.States.Support;
using System;
using UnityEngine;

namespace Assets.Script.Core.Managers
{
    public class PlayerManager : GameBehaviour
    {
        private ICharacter _player = null;
        public ICharacter Player
        {
            get => _player;
            set
            {
                _player = value;
                OnSetPlayer();
            }
        }
        public Action OnSetPlayer { get; set; }
        public Action OnInvincibility { get; set; }
        public Action OnDamageable { get; set; }
        public Action OnDeath { get; set; }
        public Action OnLevelClear { get; set; }
        public Action OnInstantiatePlayer { get; set; }

        [field: SerializeField]
        public StartingPoint StartPosition { get; set; }
    }
}
