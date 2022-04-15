using System;
using System.Threading;

namespace Project_02_SpaceInvaders_Csharp
{
    class Program
    {
        private static GameEngine gameEngine;

        private static GameSettings gameSettings;

        static UIController uIController;

        static void Main(string[] args)
        {
            Initialize();
            gameEngine.Run();
        }

        public static void Initialize()
        {
            gameSettings = new GameSettings();
            gameEngine = GameEngine.GetGameEngine(gameSettings);

            uIController = new UIController();

            uIController.OnAPressed += (obj, arg) => gameEngine.CalculateMovePlayerShipLeft();
            uIController.OnDPressed += (obj, arg) => gameEngine.CalculateMovePlayerShipRight();

            Thread uIthread = new Thread(uIController.StartListening);
            uIthread.Start();

            Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
        }
    }
}
