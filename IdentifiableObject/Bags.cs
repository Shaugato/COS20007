using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IdentifiableObject
{
    public class Bag : Item,IHaveInventory
    {
        private Inventory _inventory;
        public Bag(string[]ids, string name , string desc) : base(ids,name,desc)
        {
            _inventory = new Inventory();
        }
        public GameObject Locate(string id)
        {
            if(AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }
        public GameObject Take_Command(string id)
        {
            return _inventory.Take(id);
        }
        public string FullDescription
        {
            get { return $"In the {this.Name} you can see:\n" + Inventory.ItemList; }
        }
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}
