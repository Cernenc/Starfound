using Assets.Script.Inventories;
using Zenject;

namespace Assets.Script.Installers
{
    public class InventoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            this.Container.Bind<IInventory>().To<Inventory>().AsSingle();
        }
    }
}
