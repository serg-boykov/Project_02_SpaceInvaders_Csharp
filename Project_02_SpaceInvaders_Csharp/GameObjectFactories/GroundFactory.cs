using System.Collections.Generic;

namespace Project_02_SpaceInvaders_Csharp.GameObjectFactories
{
    /// <summary>
    /// Ground object factory.
    /// </summary>
    class GroundFactory : GameObjectFactory
    {
        public GroundFactory(GameSettings gameSettings)
            : base(gameSettings)
        {

        }

        /// <summary>
        /// Creating a new ground object in the place on the screen.
        /// </summary>
        /// <param name="objectPlace">The place on the screen.</param>
        /// <returns>The new ground object.</returns>
        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            GameObject groundObject = new GroundObject()
            {
                Figure = GameSettings.Ground,
                GameObjectPlace = objectPlace,
                GameObjectType = GameObjectType.GroundObject
            };

            return groundObject;
        }

        /// <summary>
        /// Creating the list of ground objects.
        /// </summary>
        /// <returns>The list of ground objects.</returns>
        public List<GameObject> GetGround()
        {
            List<GameObject> ground = new List<GameObject>();

            int startX = GameSettings.GroundStartXCoordinate;
            int startY = GameSettings.GroundStartYCoordinate;

            for (int y = 0; y < GameSettings.NumberOfGroundRows; y++)
            {
                for (int x = 0; x < GameSettings.NumberOfGroundCols; x++)
                {
                    GameObjectPlace objectPlace = new GameObjectPlace()
                    { XCoordinate = startX + x, YCoordinate = startY + y };

                    GameObject groundObj = GetGameObject(objectPlace);

                    ground.Add(groundObj);
                }
            }

            return ground;
        }

    }
}
