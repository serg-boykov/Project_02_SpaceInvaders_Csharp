namespace Project_02_SpaceInvaders_Csharp.GameObjectFactories
{
    /// <summary>
    /// Player ship factory.
    /// </summary>
    class PlayerShipFactory : GameObjectFactory
    {
        public PlayerShipFactory(GameSettings gameSettings)
            : base(gameSettings)
        {

        }

        /// <summary>
        /// Creating the player ship in the place on the screen.
        /// </summary>
        /// <param name="objectPlace">The place on the screen.</param>
        /// <returns>The player ship.</returns>
        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            GameObject playerShip = new PlayerShip()
            {
                Figure = GameSettings.PlayerShip,
                GameObjectPlace = objectPlace,
                GameObjectType = GameObjectType.PlayerShip
            };

            return playerShip;
        }

        /// <summary>
        /// Creating the player ship.
        /// </summary>
        /// <returns>The player ship.</returns>
        public GameObject GetGameObject()
        {
            GameObjectPlace place = new GameObjectPlace()
            {
                XCoordinate = GameSettings.PlayerShipStartXCoordinate,
                YCoordinate = GameSettings.PlayerShipStartYCoordinate
            };

            return GetGameObject(place);
        }
    }
}
