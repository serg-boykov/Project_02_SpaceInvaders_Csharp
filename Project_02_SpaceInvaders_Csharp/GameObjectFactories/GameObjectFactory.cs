using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_02_SpaceInvaders_Csharp.GameObjectFactories
{
    abstract class GameObjectFactory
    {
        public GameSettings GameSettings { get; set; }

        public abstract GameObject GetGameObject(GameObjectPlace objectPlace);

        public GameObjectFactory(GameSettings gameSettings)
        {
            GameSettings = gameSettings;
        }
    }
}
