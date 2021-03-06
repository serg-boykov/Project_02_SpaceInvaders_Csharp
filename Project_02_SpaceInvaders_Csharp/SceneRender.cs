using System;
using System.Collections.Generic;
using System.Text;

namespace Project_02_SpaceInvaders_Csharp
{
    /// <summary>
    /// Rendering all objects in the scene.
    /// </summary>
    class SceneRender
    {
        /// <summary>
        /// Width of the Console Screen.
        /// </summary>
        private int _screenWidth;

        /// <summary>
        /// Height of the Console Screen.
        /// </summary>
        private int _screenHeight;

        /// <summary>
        /// An array of characters on the square Console area.
        /// </summary>
        private char[,] _sreenMatrix;

        /// <summary>
        /// Height of the Control Panel area.
        /// </summary>
        private int _controlPanelHeight;

        /// <summary>
        /// Class SceneRender constructor.
        /// </summary>
        /// <param name="gameSettings">Game settings.</param>
        public SceneRender(GameSettings gameSettings)
        {
            _screenWidth = gameSettings.ConsoleWidth;
            _screenHeight = gameSettings.ConsoleHeight;
            _sreenMatrix = new char[gameSettings.ConsoleHeight, gameSettings.ConsoleWidth];
            _controlPanelHeight = gameSettings.ConsoleCtrlPanelHeight;

            Console.WindowHeight = gameSettings.ConsoleHeight;
            Console.WindowWidth = gameSettings.ConsoleWidth;

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// Rendering of the scene of all objects.
        /// </summary>
        /// <param name="scene">The scene of all objects.</param>
        public void Render(Scene scene)
        {
            ClearScreen();

            Console.SetCursorPosition(0, 0);

            // Creating all objects.
            AddListForRandering(scene.swarm);
            AddListForRandering(scene.ground);
            AddListForRandering(scene.playerShipMissile);
            AddListForRandering(scene.alienShipBomb);
            AddGameObjectForRendering(scene.playerShip);

            StringBuilder stringBuilder = new StringBuilder();

            // Rendering all objects.
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

        /// <summary>
        /// Adding the Game Object to the screen array.
        /// </summary>
        /// <param name="gameObject">Game object.</param>
        public void AddGameObjectForRendering(GameObject gameObject)
        {
            bool isObjectPlace = gameObject.GameObjectPlace.YCoordinate < _sreenMatrix.GetLength(0) &&
                                 gameObject.GameObjectPlace.XCoordinate < _sreenMatrix.GetLength(1);
            if (isObjectPlace)
            {
                _sreenMatrix[gameObject.GameObjectPlace.YCoordinate, gameObject.GameObjectPlace.XCoordinate] =
                    gameObject.Figure;
            }
        }

        /// <summary>
        /// Adding the List of Game Objects to the screen array.
        /// </summary>
        /// <param name="gameObjects">The List of Game Objects.</param>
        public void AddListForRandering(List<GameObject> gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                AddGameObjectForRendering(gameObject);
            }
        }

        /// <summary>
        /// Cleaning the screen.
        /// </summary>
        public void ClearScreen()
        {
            for (int y = 0; y < _screenHeight - _controlPanelHeight; y++)
            {
                for (int x = 0; x < _screenWidth; x++)
                {
                    _sreenMatrix[y, x] = ' ';
                }
            }
        }

        /// <summary>
        /// Control panel information on the screen.
        /// </summary>
        public void ControlPanel()
        {
            Console.SetCursorPosition(0, 25);
            Console.WriteLine(new string('-', 32) + " Control  Panel " + new string('-', 32));
            Console.WriteLine("Key 'P' - Pause");
            Console.WriteLine("Key 'ESC' - Game Quit");

            Console.WriteLine("Key 'Enter' - To Finish the Game and Show Score");
            Console.WriteLine("Then 2 times key 'Enter' - Start New Game");

            Console.WriteLine("Keys '<-  ->' - Move Player Ship to Left and to Right");
            Console.WriteLine("Key 'SpaceBar' - Shoot to Alien Ships");
        }

        /// <summary>
        /// 'Game over' information on the screen.
        /// </summary>
        public void RenderGameOver()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("GAME  OVER");

            Console.SetCursorPosition(35, 1);
            Console.WriteLine(stringBuilder.ToString());
        }

        /// <summary>
        /// Print the score on screen.
        /// </summary>
        /// <param name="gameSettings">Game settings.</param>
        /// <param name="scoreAlienShips">Alien ships destroyed.</param>
        /// <param name="scoreGroundObjects">Ground objects remained.</param>
        public void GetScore(GameSettings gameSettings, int scoreAlienShips, int scoreGroundObjects)
        {
            Console.SetCursorPosition(2, 22);
            Console.WriteLine("SCORE:");
            Console.SetCursorPosition(2, 23);
            Console.WriteLine($"Alien ships destroyed: {scoreAlienShips} " +
                $"из {gameSettings.NumberOfSwarmRows * gameSettings.NumberOfSwarmCols}");
            Console.SetCursorPosition(2, 24);
            Console.WriteLine($"Ground objects remained: {scoreGroundObjects} " +
                $"из {gameSettings.NumberOfGroundRows * gameSettings.NumberOfGroundCols}");
        }
    }
}
