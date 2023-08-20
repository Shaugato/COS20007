using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Path> _paths;

        //private bool _playerInLocation;

        public Location(string name, string description, string[] ids) : base(ids, name, description)
        {
            _inventory = new Inventory();
            _paths = new List<Path>();
        }
        public Location(string name, string description, string[] ids, List<Path> path) : this(name, description, ids)
        {
            _paths = path;
        }
        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            foreach (Path path in _paths)
            {
                if (path.AreYou(id))
                {
                    return path;
                }
            }
            return _inventory.Fetch(id);

        }

        public void AddToPath(Path path)
        {
            _paths.Add(path);
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
        public GameObject Take_Command(string id)
        {
            return _inventory.Take(id);
        }
        public override string FullDescription
        {
            get
            {
                return "You are at " + this.Name + "\n" + base.FullDescription + "\nYou can see: \n " + _inventory.ItemList;
            }
        }
    }
}
