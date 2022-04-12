using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_02_SpaceInvaders_Csharp
{
    class Scene
    {
        private List<GameObject> _swarm;

        private List<GameObject> _ground;

        private GameObject _playerShip;

        private List<GameObject> _playerShipMissile;

        private static Scene _scene;

        private Scene()
        {
            
        }

        private Scene(GameSettings gameSettings)
        {
            
        }

        public Scene GetScene(GameSettings gameSettings)
        {
            if (_scene == null)
            {
                _scene = new Scene(gameSettings);
            }

            return _scene;
        }
    }
}
