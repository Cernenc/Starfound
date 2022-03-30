using Assets.Script.Factories;
using Assets.Script.PlayableCharacters.Interfaces;
using Zenject;

namespace Assets.Script.Installers
{
    public class TestInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CharacterFactory.Settings>().AsSingle();
            Container.BindFactory<ICharacter, Factory>().FromFactory<CharacterFactory>();
        }
    }
}
