using Assets.Script.PlayableCharacters.Interfaces;
using Zenject;

namespace Assets.Script.Installers
{
    public class ICharacterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            this.Container.Bind<ICharacter>().To<PlayableCharacters.Star>().AsSingle();
        }
    }
}
