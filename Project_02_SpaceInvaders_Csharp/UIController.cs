using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_02_SpaceInvaders_Csharp
{
    class UIController
    {
        public event EventHandler OnAPressed;
        public event EventHandler OnDPressed;
        public event EventHandler OnSpacePressed;

        public void StartListening()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key.Equals(ConsoleKey.A))
                {
                    OnAPressed?.Invoke(this, new EventArgs());
                }
                else if (key.Key.Equals(ConsoleKey.D))
                {
                    OnDPressed?.Invoke(this, new EventArgs());
                }
                else if (key.Key.Equals(ConsoleKey.Spacebar))
                {
                    OnSpacePressed?.Invoke(this, new EventArgs());
                }
                else
                {
                    ;
                }
                
                //// Другой вариант в видео 3:17:32
                //if (OnAPressed != null) { OnAPressed(this, EventArgs.Empty); }
                //else if (OnDPressed != null) { OnDPressed(this, EventArgs.Empty); }
                //else
                //{
                //    ;
                //}
            }
        }
    }
}
