using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_02_SpaceInvaders_Csharp
{
    class GameObjectPlace
    {
        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public override bool Equals(object obj)
        {
            GameObjectPlace other = obj as GameObjectPlace;

            if (other == null) return false;
            return other.XCoordinate == XCoordinate && other.YCoordinate == YCoordinate;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
