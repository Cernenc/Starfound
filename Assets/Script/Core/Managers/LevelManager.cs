using System;

namespace Assets.Script.Core.Managers
{
    public interface ILevelManager
    {
        Action OnLoadLevel { get; set; }
        void LoadLevel();
    }

    public class LevelManager : ILevelManager
    {
        public Action OnLoadLevel { get; set; }
        public void LoadLevel()
        {
            //level prefab of type gameobject
            //parent of type transform
            OnLoadLevel?.Invoke();
        }
    }
}
