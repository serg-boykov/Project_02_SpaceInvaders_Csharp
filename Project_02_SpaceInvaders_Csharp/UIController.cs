using System;

namespace Project_02_SpaceInvaders_Csharp
{
    class UIController
    {
        public event EventHandler OnLPressed;
        public event EventHandler OnRPressed;
        public event EventHandler OnSpacePressed;

        public event EventHandler OnPausePressed;
        public event EventHandler OnEscapePressed;
        public event EventHandler OnEnterPressed;

        public void StartListening()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key.Equals(ConsoleKey.LeftArrow))
                {
                    OnLPressed?.Invoke(this, new EventArgs());
                }
                else if (key.Key.Equals(ConsoleKey.RightArrow))
                {
                    OnRPressed?.Invoke(this, new EventArgs());
                }
                else if (key.Key.Equals(ConsoleKey.Spacebar))
                {
                    OnSpacePressed?.Invoke(this, new EventArgs());
                }
                else if (key.Key.Equals(ConsoleKey.P))
                {
                    OnPausePressed?.Invoke(this, new EventArgs());
                }
                else if (key.Key.Equals(ConsoleKey.Escape))
                {
                    OnEscapePressed?.Invoke(this, new EventArgs());
                }
                else if (key.Key.Equals(ConsoleKey.Enter))
                {
                    OnEnterPressed?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
