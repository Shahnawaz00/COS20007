using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Path : GameObject
    {
        private Location _destination;
        private bool _isLocked;
        public Path(string[] ids, string name, string desc, Location destination) : base(ids, name, desc)
        {
            _destination = destination;
        }

        public Location Destination => _destination;

        public override string FullDescription => $"At {Name} lies {Destination.Name}";

        public bool IsLocked
        {
            get => _isLocked; 
            set => _isLocked = value; 
        }
    }
}
