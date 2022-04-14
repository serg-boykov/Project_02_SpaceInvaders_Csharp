using System;

namespace Project_02_SpaceInvaders_Csharp
{
    class Program
    {
        private static GameEngine gameEngine;

        private static GameSettings gameSettings;

        static void Main(string[] args)
        {
            Initialize();
            gameEngine.Run();
        }

        public static void Initialize()
        {
            gameSettings = new GameSettings();
            gameEngine = GameEngine.GetGameEngine(gameSettings);
        }
    }
}
