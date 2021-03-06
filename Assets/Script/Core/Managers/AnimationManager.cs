using Assets.Script.Core.Managers;
using System;
using UnityEngine;
using Zenject;

/// <summary>
/// Better practice necessary
/// </summary>
namespace Assets.Script.Core.Managers
{
    public interface IAnimationManager
    {
        void SpecialMoveAnimation();
        void Flashing();
        Animator PlayerAnimator { get; set; }
    }

    public class AnimationManager : IAnimationManager
    {
        public Animator PlayerAnimator { get; set; }

        [Inject]
        private IPlayerManager playerManager;

        public void Flashing()
        {
            if (playerManager.Player.Components.Rigidbody.transform.localScale == Vector3.one)
            {
                ScaleModelTo(Vector3.zero);
            }
            else if (playerManager.Player.Components.Rigidbody.transform.localScale == Vector3.zero)
            {
                ScaleModelTo(Vector3.one);
            }
        }

        public void ScaleModelTo(Vector3 scale)
        {
            playerManager.Player.Components.Rigidbody.transform.localScale = scale;
        }

        public void IdleAnimation()
        {
            PlayerAnimator.SetBool("IsIdle", true);
            PlayerAnimator.SetBool("IsMoving", false);
            PlayerAnimator.SetBool("IsHit", false);
            PlayerAnimator.SetBool("IsDead", false);
        }

        public void MoveAnimation()
        {
            PlayerAnimator.SetBool("IsMoving", true);
            PlayerAnimator.SetBool("IsHit", false);
            PlayerAnimator.SetBool("IsDead", false);
        }

        public void HitAnimation()
        {
            PlayerAnimator.SetBool("IsIdle", false);
            PlayerAnimator.SetBool("IsMoving", false);
            PlayerAnimator.SetBool("IsHit", true);
            PlayerAnimator.SetBool("IsDead", false);
        }

        public void DeathAnimation()
        {
            PlayerAnimator.SetBool("IsIdle", false);
            PlayerAnimator.SetBool("IsMoving", false);
            PlayerAnimator.SetBool("IsHit", false);
            PlayerAnimator.SetBool("IsDead", true);
        }
        public void SpecialMoveAnimation()
        {

        }
    }
}