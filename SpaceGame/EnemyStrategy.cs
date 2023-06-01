using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public interface EnemyStrategy
    {
        public abstract void Behaviour(ref float y,ref float speed);
    }
}
