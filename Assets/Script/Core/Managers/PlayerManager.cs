using Assets.Script.PlayableCharacters.Interfaces;
using System;
using UnityEngine;

namespace Assets.Script.Core.Managers
{
    public interface IPlayerManager
    {
        ICharacter Player { get; set; }
        Action OnSetPlayer { get; set; }
        Action OnInvincibility { get; set; }
        Action OnIsDamageable { get; set; }
        Action OnDeath { get; set; }
        Action OnLevelClear { get; set; }
        Action OnInstantiatePlayer { get; set; }
    }
    public class PlayerManager : IPlayerManager
    {
        private ICharacter _player = null;
        public ICharacter Player
        {
            get => _player;
            set
            {
                _player = value;
                OnSetPlayer.Invoke();
            }
        }

        public Action OnSetPlayer { get; set; }
        public Action OnInvincibility { get; set; }
        public Action OnIsDamageable { get; set; }
        public Action OnDeath { get; set; }
        public Action OnLevelClear { get; set; }
        public Action OnInstantiatePlayer { get; set; }
    }
}
