using Project_02_SpaceInvaders_Csharp.GameObjectFactories;
using System.Collections.Generic;

namespace Project_02_SpaceInvaders_Csharp
{
    /// <summary>
    /// Creating a scene of objects.
    /// </summary>
    class Scene
    {
        /// <summary>
        /// Objects of alien ships.
        /// </summary>
        public List<GameObject> swarm;

        /// <summary>
        /// Objects of ground.
        /// </summary>
        public List<GameObject> ground;

        /// <summary>
        /// Player ship.
        /// </summary>
        public GameObject playerShip;

        /// <summary>
        /// Player ship missile objects.
        /// </summary>
        public List<GameObject> playerShipMissile;

        /// <summary>
        /// Alien ships bomb objects.
        /// </summary>
        public List<GameObject> alienShipBomb;

        /// <summary>
        /// Game settings.
        /// </summary>
        private GameSettings _gameSettings;

        /// <summary>
        /// Scene of all objects.
        /// </summary>
        private static Scene _scene;

        private Scene()
        {

        }

        /// <summary>
        /// Class Scene constructor.
        /// </summary>
        /// <param name="gameSettings">Game settings.</param>
        private Scene(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            swarm = new AlienShipFactory(_gameSettings).GetSwarm();
            ground = new GroundFactory(_gameSettings).GetGround();
            playerShip = new PlayerShipFactory(_gameSettings).GetGameObject();
            playerShipMissile = new List<GameObject>();
            alienShipBomb = new List<GameObject>();
        }

        /// <summary>
        /// Getting the scene of all objects.
        /// </summary>
        /// <param name="gameSettings">Game settings.</param>
        /// <returns>Scene of all objects.</returns>
        public static Scene GetScene(GameSettings gameSettings)
        {
            _scene = new Scene(gameSettings);

            return _scene;
        }
    }
}
