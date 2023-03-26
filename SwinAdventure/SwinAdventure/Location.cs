using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;

        public Location(string name, string desc) : base(new string[] {"room", "here"}, name, desc) 
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            else return null;
        }

        public override string FullDescription
        {
            get
            {
                return $"You are in {Name}\n{Description}\nIn this room you can see:\n{_inventory.ItemList}";
            }
        }
        public Inventory Inventory => _inventory;
    }
}
