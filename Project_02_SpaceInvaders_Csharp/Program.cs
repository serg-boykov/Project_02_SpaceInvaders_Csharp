using System;
using System.Threading;

namespace Project_02_SpaceInvaders_Csharp
{
    class Program
    {
        private static GameEngine gameEngine;

        private static GameSettings gameSettings;

        static UIController uIController;

        static MusicController musicController;

        static void Main(string[] args)
        {
            Initialize();

            while (true)
            {
                gameEngine.Run();

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter)
                {
                    gameSettings = new GameSettings();
                    gameEngine = GameEngine.GetGameEngine(gameSettings);
                }
            }
        }

        public static void Initialize()
        {
            gameSettings = new GameSettings();
            gameEngine = GameEngine.GetGameEngine(gameSettings);

            uIController = new UIController();

            uIController.OnLPressed += (obj, arg) => gameEngine.CalculateMovePlayerShipLeft();
            uIController.OnRPressed += (obj, arg) => gameEngine.CalculateMovePlayerShipRight();
            uIController.OnSpacePressed += (obj, arg) => gameEngine.Shoot();

            uIController.OnPausePressed += (obj, arg) => gameEngine.PauseGame();
            uIController.OnEscapePressed += (obj, arg) => gameEngine.ExitGame();
            uIController.OnEnterPressed += (obj, arg) => gameEngine.StartGame();

            Thread uIthread = new Thread(uIController.StartListening);
            uIthread.Start();

            musicController = new MusicController();
            Thread musicThread = new Thread(musicController.PlayBackgroundMusic);
            musicThread.Start();

            Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
        }
    }
}
