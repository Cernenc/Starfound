using Assets.Script.Core.Managers;
using Zenject;

namespace Assets.Script.Installers
{
    public class ManagerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            this.Container.Bind<ManagerDependencyInjection>().AsSingle();
            this.Container.Bind<IGameManager>().To<GameManager>().AsSingle();
            this.Container.Bind<IInputManager>().To<InputManager>().AsSingle();
            this.Container.Bind<IPlayerManager>().To<PlayerManager>().AsSingle();
            this.Container.Bind<IAnimationManager>().To<AnimationManager>().AsSingle();
            this.Container.Bind<IMenuManager>().To<MenuManager>().AsSingle();
            this.Container.Bind<ILevelManager>().To<LevelManager>().AsSingle();
        }
    }
}
