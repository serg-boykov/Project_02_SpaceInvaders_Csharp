using System;

namespace Project_02_SpaceInvaders_Csharp
{
    /// <summary>
    /// Key Control Class.
    /// </summary>
    class UIController
    {
        /// <summary>
        /// The event is pressing the LeftArrow key.
        /// </summary>
        public event EventHandler OnLPressed;

        /// <summary>
        /// The event is pressing the RightArrow key.
        /// </summary>
        public event EventHandler OnRPressed;

        /// <summary>
        /// The event is pressing the SpaceBar key.
        /// </summary>
        public event EventHandler OnSpacePressed;

        /// <summary>
        /// The event is pressing the P key.
        /// </summary>
        public event EventHandler OnPausePressed;

        /// <summary>
        /// The event is pressing the Esc key.
        /// </summary>
        public event EventHandler OnEscapePressed;

        /// <summary>
        /// The event is pressing the Enter key.
        /// </summary>
        public event EventHandler OnEnterPressed;

        /// <summary>
        /// Monitoring keystrokes.
        /// </summary>
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
