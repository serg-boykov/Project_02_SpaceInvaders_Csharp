namespace Project_02_SpaceInvaders_Csharp.GameObjectFactories
{
    /// <summary>
    /// Alien ship bomb factory.
    /// </summary>
    internal class AlienShipBombFactory : GameObjectFactory
    {
        public AlienShipBombFactory(GameSettings gameSettings)
            : base(gameSettings)
        {

        }

        /// <summary>
        /// Creating a new alien bomb in the place on the screen.
        /// </summary>
        /// <param name="objectPlace">The place on the screen.</param>
        /// <returns>The new bomb.</returns>
        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            GameObjectPlace bombPlace = new GameObjectPlace()
            {
                XCoordinate = objectPlace.XCoordinate,
                YCoordinate = objectPlace.YCoordinate + 1
            };

            GameObject bomb = new AlienShipBomb()
            {
                Figure = GameSettings.AlienBomb,
                GameObjectPlace = bombPlace,
                GameObjectType = GameObjectType.AlienShipBomb
            };

            return bomb;
        }
    }
}
