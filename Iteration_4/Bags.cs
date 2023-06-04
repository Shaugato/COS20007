using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Iteration_4_3
{
    public class Bag : Item, IHaveInventory
    {
        Inventory _inventory;

        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }

        public override string FullDescription
        {

            get
            {
                return $" You are carring a container .\nIn the {this.Name} you can see:\n" + _inventory.ItemList;
            }
        }
        public Inventory Inventory
        {
            get => _inventory;
        }
    }
}

