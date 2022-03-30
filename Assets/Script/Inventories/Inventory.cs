using Assets.Script.Collectables.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Inventories
{
    public interface IInventory
    {
        List<ISpecialnote> PowernoteList { get; }
        List<ISpecialnote> SpinnoteList { get; }
        List<ISpecialnote> SpeedupnoteList { get; }
        void AddItem(List<ISpecialnote> list, ISpecialnote item);
        void RemoveItem(List<ISpecialnote> list);
        void UseItem();
    }

    public class Inventory : IInventory
    {
        public List<ISpecialnote> PowernoteList { get; }
        public List<ISpecialnote> SpinnoteList { get; }
        public List<ISpecialnote> SpeedupnoteList { get; }

        public Inventory()
        {
            if(PowernoteList == null)
            {
                PowernoteList = new List<ISpecialnote>();
            }
            if(SpinnoteList == null)
            {
                SpinnoteList = new List<ISpecialnote>();
            }
            if(SpeedupnoteList == null)
            {
                SpeedupnoteList = new List<ISpecialnote>();
            }
        }

        public void AddItem(List<ISpecialnote> list, ISpecialnote item)
        {
            list.Add(item);
        }

        public void RemoveItem(List<ISpecialnote> list)
        {
            if(list.Count <= 0)
            {
                return;
            }

            list.RemoveAt(list.Count - 1);
        }

        public void UseItem()
        {
            Debug.Log("Using item");
        }
    }
}
