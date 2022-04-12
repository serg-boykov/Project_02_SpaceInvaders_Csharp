using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_02_SpaceInvaders_Csharp
{
    abstract class GameObject
    {
        public GameObjectPlace GameObjectPlace { get; set; }

        public char Figure { get; set; }

        public GameObjectType GameObjectType { get; set; }
    }
}
