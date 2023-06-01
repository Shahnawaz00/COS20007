using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class HardEnemy : EnemyStrategy
    {
        public HardEnemy() { }

        public void Behaviour(ref float y,ref float speed)
        {
            y += speed * 2;
        }
    }
}
