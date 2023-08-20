using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        Location location;
        public Player(string name, string desc, Location Location) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
            location = Location;
        }

        public Location Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;

            }
            GameObject obj = _inventory.Fetch(id);
            if (obj != null)
            {
                return obj;
            }
            if (location != null)
            {
                obj = location.Locate(id);
                return obj;
            }
            else
            {
                return null;
            }

        }
        public override string FullDescription
        {
            get
            {
                return $"You are {this.Name} {base.FullDescription}\nYou are carrying:\n{_inventory.ItemList}";
            }
        }
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
        public void MoveTo(Path path)
        {
            if (path.Destination != null)
            {
                location = path.Destination;
            }
        }

        public GameObject Take_Command(string id)
        {
            return Inventory.Take(id);
        }
    }
}
