using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Inventories
{
    public interface IInventoryView
    {
        Action OnAddItem { get; set; }
        Action OnRemoveItem { get; set; }
    }

    public class InventoryView : MonoBehaviour, IInventoryView
    {
        public Action OnAddItem { get; set; }
        public Action OnRemoveItem { get; set; }
    }
}
