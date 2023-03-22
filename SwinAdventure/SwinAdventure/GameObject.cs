using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        //local variables
        private string _name;
        private string _description;

        //constructor 
        public GameObject(string[] ids, string name, string desc) : base(ids) 
        {
            _name = name;
            _description = desc;
        }

        //properties, using the => shorthand since theyre all read only
        public string Name => _name;

        public string Description => _description;
        public string ShortDescription => $"{Name} ({FirstId})";
        public virtual string FullDescription => _description;

    }
}
