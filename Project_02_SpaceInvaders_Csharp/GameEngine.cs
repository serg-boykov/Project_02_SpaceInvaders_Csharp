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
            do
            {
                _sceneRender.ClearScreen();
                _sceneRender.Render(_scene);

                Thread.Sleep(_gameSettings.GameSpeed);

            } while (_isNotOver);
        }
    }
}
