using UnityEngine;

namespace Assets.Script.Core.Managers
{
    public class CachedComponent<T> where T : UnityEngine.Object
    {
        private T _cache;

        public void Clear()
        {
            _cache = null;
        }

        public T Instance(MonoBehaviour container)
        {
            if(_cache == null)
            {
                var possibles = GameObject.FindObjectsOfType<T>();
                if (possibles.Length == 0)
                {
                    Debug.LogError($"No {typeof(T).Name} found when {container.name} searched for instances.");
                }
                else
                {
                    _cache = possibles[0];
                    if(possibles.Length > 1)
                    {
                        Debug.LogError($"Multiple {typeof(T).Name} found when {container.name} searched for instances.");
                    }
                }
            }
            return _cache;
        }
    }
}
