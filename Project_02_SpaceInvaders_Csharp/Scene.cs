using Project_02_SpaceInvaders_Csharp.GameObjectFactories;
using System.Collections.Generic;

namespace Project_02_SpaceInvaders_Csharp
{
    class Scene
    {
        public List<GameObject> swarm;

        public List<GameObject> ground;

        public GameObject playerShip;

        public List<GameObject> playerShipMissile;

        public List<GameObject> alienShipBomb;

        private GameSettings _gameSettings;

        private static Scene _scene;

        private Scene()
        {

        }

        private Scene(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            swarm = new AlienShipFactory(_gameSettings).GetSwarm();
            ground = new GroundFactory(_gameSettings).GetGround();
            playerShip = new PlayerShipFactory(_gameSettings).GetGameObject();
            playerShipMissile = new List<GameObject>();
            alienShipBomb = new List<GameObject>();
        }

        public static Scene GetScene(GameSettings gameSettings)
        {
            if (_scene == null)
            {
                _scene = new Scene(gameSettings);
            }

            return _scene;
        }
    }
}
