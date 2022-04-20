namespace Project_02_SpaceInvaders_Csharp.GameObjectFactories
{
    /// <summary>
    /// Player ship missile factory.
    /// </summary>
    class PlayerShipMissileFactory : GameObjectFactory
    {
        public PlayerShipMissileFactory(GameSettings gameSettings)
            : base(gameSettings)
        {

        }

        /// <summary>
        /// Creating a new missile in the place on the screen.
        /// </summary>
        /// <param name="objectPlace">The place on the screen.</param>
        /// <returns>The new missile.</returns>
        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            GameObjectPlace missilePlace = new GameObjectPlace() 
            { 
                XCoordinate = objectPlace.XCoordinate,
                YCoordinate = objectPlace.YCoordinate - 1
            };

            GameObject missile = new PlayerShipMissile()
            {
                Figure = GameSettings.PlayerMissile,
                GameObjectPlace = missilePlace,
                GameObjectType = GameObjectType.PlayerShipMissile
            };

            return missile;
        }
    }
}
