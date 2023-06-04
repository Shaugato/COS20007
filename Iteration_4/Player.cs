using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration_4_3
{
    public class Player : GameObject, IHaveInventory
    {
        Inventory _inventory;

        public Player(string name, string desc) :
            base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public override string FullDescription
        {
            get { return $"You are {this.Name} {base.FullDescription}\nYou are carrying:\n{_inventory.ItemList}"; }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
                return this;

            GameObject obj = _inventory.Fetch(id);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }

        public Inventory Inventory
        {
            get => _inventory;
        }
    }
}
