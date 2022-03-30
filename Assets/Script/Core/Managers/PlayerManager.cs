using Assets.Script.PlayableCharacters.Interfaces;
using System;

namespace Assets.Script.Core.Managers
{
    public interface IPlayerManager
    {
        ICharacter Player { get; set; }
        Action OnMoving { get; set; }
        Action OnGettingDamaged { get; set; }
        Action OnIsInvincible { get; set; }
        Action OnDeath { get; set; }
        void SpecialMove();
        void HandleHorizontalMovement(float horizontal);
        void HandleVerticalMovement(float vertical);
    }

    public class PlayerManager : IPlayerManager
    {
        public ICharacter Player { get; set; }
        public Action OnMoving { get; set; }
        public Action OnGettingDamaged { get; set; }
        public Action OnDeath { get; set; }
        public Action OnIsInvincible { get; set; }

        public void SpecialMove()
        {
            throw new NotImplementedException();
        }

        public void HandleHorizontalMovement(float horizontal)
        {
            Player.Horizontal = horizontal;
        }

        public void HandleVerticalMovement(float vertical)
        {
            Player.Vertical = vertical;
        }
    }
}
