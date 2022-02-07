using Assets.Script.PlayableCharacters.Health;
using Zenject;

namespace Assets.Script.Installers
{
    public class GaugeInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            this.Container.Bind<IGauge>().To<Gauge>().AsSingle();
        }
    }
}
