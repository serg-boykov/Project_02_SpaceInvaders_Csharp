﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_02_SpaceInvaders_Csharp.GameObjectFactories
{
    class PlayerShipFactory : GameObjectFactory
    {
        public PlayerShipFactory(GameSettings gameSettings)
            : base(gameSettings)
        {
            
        }

        public override GameObject GetGameObject(GameObjectPlace objectPlace)
        {
            GameObject gameObject = new PlayerShip()
            {
                Figure = GameSettings.PlayerShip, GameObjectPlace = objectPlace, GameObjectType = GameObjectType.PlayerShip
            };

            return gameObject;
        }

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
