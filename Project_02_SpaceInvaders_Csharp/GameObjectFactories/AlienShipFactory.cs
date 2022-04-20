using System.Collections.Generic;

namespace Project_02_SpaceInvaders_Csharp.GameObjectFactories
{
    /// <summary>
    /// Alien ship factory.
    /// </summary>
    class AlienShipFactory : GameObjectFactory
    {
        public AlienShipFactory(GameSettings gameSettings)
            : base(gameSettings)
        {

        }

        /// <summary>
        /// Creating a new alien ship in the place on the screen.
        /// </summary>
        /// <param name="objectPlace">The place on the screen.</param>
        /// <returns>The new alien ship.</returns>
        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            GameObject alienShip = new AlienShip()
            {
                Figure = GameSettings.AlienShip,
                GameObjectPlace = objectPlace,
                GameObjectType = GameObjectType.AlienShip
            };

            return alienShip;
        }

        /// <summary>
        /// Creating the swarm of alien ships.
        /// </summary>
        /// <returns>The swarm of alien ships.</returns>
        public List<GameObject> GetSwarm()
        {
            List<GameObject> swarm = new List<GameObject>();

            int startX = GameSettings.SwarmStartXCoordinate;
            int startY = GameSettings.SwarmStartYCoordinate;

            for (int y = 0; y < GameSettings.NumberOfSwarmRows; y++)
            {
                for (int x = 0; x < GameSettings.NumberOfSwarmCols; x++)
                {
                    GameObjectPlace objectPlace = new GameObjectPlace()
                    { XCoordinate = startX + x, YCoordinate = startY + y };

                    GameObject alienShip = GetGameObject(objectPlace);

                    swarm.Add(alienShip);
                }
            }

            return swarm;
        }
    }
}
