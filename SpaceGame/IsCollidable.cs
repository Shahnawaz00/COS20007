using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public interface IsCollidable
    {
        Bitmap Bitmap { get; }
        float X { get; }
        float Y { get; }
        bool IsCollidingWith(IsCollidable o);
    }
}
