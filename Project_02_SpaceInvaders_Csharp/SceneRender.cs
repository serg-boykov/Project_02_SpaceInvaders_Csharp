using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_02_SpaceInvaders_Csharp
{
    class SceneRender
    {
        private int _screenWidth;
        private int _screenHeight;
        private char[,] _sreenMatrix;

        public SceneRender(GameSettings gameSettings)
        {
            _screenWidth = gameSettings.ConsoleWidth;
            _screenHeight = gameSettings.ConsoleHeight;
            _sreenMatrix = new char[gameSettings.ConsoleHeight, gameSettings.ConsoleWidth];

            Console.WindowHeight = gameSettings.ConsoleHeight;
            Console.WindowWidth = gameSettings.ConsoleWidth;

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        public void Render(Scene scene)
        {
            //Console.Clear();
            ClearScreen();
            
            Console.SetCursorPosition(0, 0);

            AddListForRandering(scene.swarm);
            AddListForRandering(scene.ground);
            AddListForRandering(scene.playerShipMissile);

            AddGameObjectForRendering(scene.playerShip);

            StringBuilder stringBuilder = new StringBuilder();

            for (int y = 0; y < _screenHeight; y++)
            {
                for (int x = 0; x < _screenWidth; x++)
                {
                    stringBuilder.Append(_sreenMatrix[y, x]);
                }

                stringBuilder.Append(Environment.NewLine);
            }

            Console.WriteLine(stringBuilder.ToString());

            Console.SetCursorPosition(0, 0);
        }

        public void AddGameObjectForRendering(GameObject gameObject)
        {
            if (gameObject.GameObjectPlace.YCoordinate < _sreenMatrix.GetLength(0) &&
                gameObject.GameObjectPlace.XCoordinate < _sreenMatrix.GetLength(1))
            {
                _sreenMatrix[gameObject.GameObjectPlace.YCoordinate, gameObject.GameObjectPlace.XCoordinate] =
                    gameObject.Figure;
            }
            else
            {
                ; //_sreenMatrix[gameObject.GameObjectPlace.YCoordinate, gameObject.GameObjectPlace.XCoordinate] = ' ';
            }
        }

        public void AddListForRandering(List<GameObject> gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                AddGameObjectForRendering(gameObject);
            }
        }

        public void ClearScreen()
        {
            //StringBuilder stringBuilder = new StringBuilder();

            for (int y = 0; y < _screenHeight; y++)
            {
                for (int x = 0; x < _screenWidth; x++)
                {
                    //stringBuilder.Append(' ');
                    _sreenMatrix[y, x] = ' ';
                }

                //stringBuilder.Append(Environment.NewLine);
            }

            Console.SetCursorPosition(0, 0);

            //Console.WriteLine(stringBuilder.ToString());
        }

        public void RenderGameOver()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Game Over!!!");

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
