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
            gameEngine.Run();
        }

        public static void Initialize()
        {
            gameSettings = new GameSettings();
            gameEngine = GameEngine.GetGameEngine(gameSettings);

            uIController = new UIController();

            uIController.OnLPressed += (obj, arg) => gameEngine.CalculateMovePlayerShipLeft();
            uIController.OnRPressed += (obj, arg) => gameEngine.CalculateMovePlayerShipRight();
            uIController.OnSpacePressed += (obj, arg) => gameEngine.Shoot();

            Thread uIthread = new Thread(uIController.StartListening);
            uIthread.Start();

            musicController = new MusicController();
            Thread musicThread = new Thread(musicController.PlayBackgroundMusic);
            musicThread.Start();

            Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
        }
    }
}
