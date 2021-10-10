using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Inventories
{
    public class InventoryController
    {
        private IInventory _model = null;
        private IInventoryView _view = null;

        public InventoryController(IInventory inventory) { }
    }
}
