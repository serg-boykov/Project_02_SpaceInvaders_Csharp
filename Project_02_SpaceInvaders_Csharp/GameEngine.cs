using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_02_SpaceInvaders_Csharp
{
    class GameEngine
    {
        private bool _isNotOver;
        
        private static GameEngine _gameEngine;

        private SceneRender _sceneRender;

        private GameSettings _gameSettings;

        private Scene _scene;

        private GameEngine()
        {
            
        }

        private GameEngine(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _isNotOver = true;
            _scene = Scene.GetScene(gameSettings);
            _sceneRender = new SceneRender(gameSettings);
        }

        public static GameEngine GetGameEngine(GameSettings gameSettings)
        {
            if (_gameEngine == null)
            {
                _gameEngine = new GameEngine(gameSettings);
            }

            return _gameEngine;
        }

        public void Run()
        {
            int swarmMoveCounter = 0;

            do
            {
                _sceneRender.Render(_scene);

                Thread.Sleep(_gameSettings.GameSpeed);

                _sceneRender.ClearScreen();

                if (swarmMoveCounter == _gameSettings.GameSpeed)
                {
                    CalculateSwarmMove();
                    swarmMoveCounter = 0;
                }

                swarmMoveCounter++;

            } while (_isNotOver);
        }

        public void CalculateMovePlayerShipLeft()
        {
            if (_scene.playerShip.GameObjectPlace.XCoordinate > 1)
            {
                _scene.playerShip.GameObjectPlace.XCoordinate--;
            }
        }

        public void CalculateMovePlayerShipRight()
        {
            if (_scene.playerShip.GameObjectPlace.XCoordinate < _gameSettings.ConsoleWidth - 1)
            {
                _scene.playerShip.GameObjectPlace.XCoordinate++;
            }
        }

        public void CalculateSwarmMove()
        {
            for (int i = 0; i < _scene.swarm.Count; i++)
            {
                GameObject alienShip = _scene.swarm[i];

                alienShip.GameObjectPlace.YCoordinate++;

                if (alienShip.GameObjectPlace.YCoordinate == _scene.playerShip.GameObjectPlace.YCoordinate)
                {
                    _isNotOver = false;
                }
            }
        }
    }
}
