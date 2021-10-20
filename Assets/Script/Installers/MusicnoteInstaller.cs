//using Assets.Script.Collectables.Controller;
using Assets.Script.Collectables.Model;
using Zenject;

namespace Assets.Script.Installers
{
    public class MusicnoteInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //this.Container.Bind<MusicnoteController>().AsSingle();
            //this.Container.Bind<SpecialnoteController>().AsSingle();
            this.Container.Bind<IMusicnoteModel>().To<MusicnoteModel>().AsSingle();
        }
    }
}
