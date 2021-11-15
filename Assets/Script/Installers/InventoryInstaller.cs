using Assets.Script.Inventories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Script.Installers
{
    public class InventoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            this.Container.Bind<IInventory>().To<Inventory>().AsSingle();
            this.Container.Bind<PlayableCharacters.Interfaces.ICharacter>().To<PlayableCharacters.Star>().AsSingle();
        }
    }
}
