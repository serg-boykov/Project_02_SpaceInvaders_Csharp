using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_02_SpaceInvaders_Csharp.GameObjectFactories;

namespace Project_02_SpaceInvaders_Csharp
{
    class Scene
    {
        private List<GameObject> _swarm;

        private List<GameObject> _ground;

        private GameObject _playerShip;

        private List<GameObject> _playerShipMissile;

        private GameSettings _gameSettings;

        private static Scene _scene;

        private Scene()
        {
            
        }

        private Scene(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _swarm = new AlienShipFactory(_gameSettings).GetSwarm();
            _ground = new GroundFactory(_gameSettings).GetGround();
            _playerShip = new PlayerShipFactory(_gameSettings).GetGameObject();
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
