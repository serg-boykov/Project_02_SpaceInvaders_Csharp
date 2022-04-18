namespace Project_02_SpaceInvaders_Csharp.GameObjectFactories
{
    internal class AlienShipBombFactory : GameObjectFactory
    {
        public AlienShipBombFactory(GameSettings gameSettings)
            : base(gameSettings)
        {

        }

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
