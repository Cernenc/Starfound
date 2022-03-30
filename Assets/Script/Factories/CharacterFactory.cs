using Assets.Script.PlayableCharacters.Interfaces;
using UnityEngine;
using Zenject;

namespace Assets.Script.Factories
{
    public class CharacterFactory : IFactory<ICharacter>
    {
        readonly DiContainer _container;
        readonly Settings _settings;
        
        public CharacterFactory(DiContainer container, Settings settings)
        {
            _container = container;
            _settings = settings;
        }

        public ICharacter Create()
        {
            return _container.InstantiatePrefabForComponent<ICharacter>(GetPrefab());
        }

        private GameObject GetPrefab()
        {
            return _settings.PlayerCharacter;
        }

        public class Settings
        {
            public GameObject PlayerCharacter { get; set; }
        }
    }
}
