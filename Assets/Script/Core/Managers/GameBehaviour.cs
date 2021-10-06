using UnityEngine;


namespace Assets.Script.Core.Managers
{
    public class GameBehaviour : MonoBehaviour
    {
        protected CachedComponent<GameManager> _gameManager = new CachedComponent<GameManager>();
        protected GameManager gameManager
        {
            get
            {
                return _gameManager.Instance(this);
            }
        }
        
        protected CachedComponent<InputManager> _inputManager = new CachedComponent<InputManager>();
        protected InputManager inputManager
        {
            get
            {
                return _inputManager.Instance(this);
            }
        }

        protected CachedComponent<PlayerManager> _playerManager = new CachedComponent<PlayerManager>();
        protected PlayerManager playerManager
        {
            get
            {
                return _playerManager.Instance(this);
            }
        }

        protected CachedComponent<AnimationManager> _animationManager = new CachedComponent<AnimationManager>();
        protected AnimationManager animationManager
        {
            get
            {
                return _animationManager.Instance(this);
            }
        }
    }
}