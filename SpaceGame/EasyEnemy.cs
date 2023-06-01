using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class EasyEnemy : EnemyStrategy
    {
        public EasyEnemy() { }

        public void Behaviour(ref float y,ref float speed)
        {
            y += speed;
        }
    }
}
