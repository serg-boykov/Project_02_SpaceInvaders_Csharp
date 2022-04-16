﻿namespace Project_02_SpaceInvaders_Csharp.GameObjectFactories
{
    class PlayerShipMissileFactory : GameObjectFactory
    {
        public PlayerShipMissileFactory(GameSettings gameSettings)
            : base(gameSettings)
        {

        }

        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            GameObjectPlace missilePlace = new GameObjectPlace() { XCoordinate = objectPlace.XCoordinate, YCoordinate = objectPlace.YCoordinate - 1 };

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
