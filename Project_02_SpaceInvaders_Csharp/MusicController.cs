﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_02_SpaceInvaders_Csharp
{
    class MusicController
    {
        public void PlayBackgroundMusic()
        {
            while (true)
            {
                
                Console.Beep(440, 500);
                Console.Beep(440, 500);
                Console.Beep(440, 500);
                Console.Beep(349, 350);
                Console.Beep(523, 150);
                Console.Beep(440, 500);
                Console.Beep(349, 350);
                Console.Beep(523, 150);
                Console.Beep(440, 1000);
                Console.Beep(659, 500);
                Console.Beep(659, 500);
                Console.Beep(659, 500);
                Console.Beep(698, 350);
                Console.Beep(523, 150);
                Console.Beep(415, 500);
                Console.Beep(349, 350);
                Console.Beep(523, 150);
                Console.Beep(440, 1000);
                Console.Beep(880, 500);
                Console.Beep(440, 350);
                Console.Beep(440, 150);
                Console.Beep(880, 500);
                Console.Beep(830, 250);
                Console.Beep(784, 250);
                Console.Beep(740, 125);
                Console.Beep(698, 125);
                Console.Beep(740, 250);
                Thread.Sleep(250); // Задержка 250 миллисекунд
                Console.Beep(455, 250);
                Console.Beep(622, 500);
                Console.Beep(587, 250);
                Console.Beep(554, 250);
                Console.Beep(523, 125);
                Console.Beep(466, 125);
                Console.Beep(523, 250);
                Thread.Sleep(250); // Задержка 250 миллисекунд
                Console.Beep(349, 125);
                Console.Beep(415, 500);
                Console.Beep(349, 375);
                Console.Beep(440, 125);
                Console.Beep(523, 150);
                Console.Beep(440, 375);
                Console.Beep(523, 125);
                Console.Beep(659, 1000);
                Console.Beep(880, 500);
                Console.Beep(440, 350);
                Console.Beep(440, 150);
                Console.Beep(880, 500);
                Console.Beep(830, 250);
                Console.Beep(784, 250);
                Console.Beep(740, 125);
                Console.Beep(698, 125);
                Console.Beep(740, 250);
                Thread.Sleep(250);
                Console.Beep(455, 250);
                Console.Beep(622, 500);
                Console.Beep(587, 250);
                Console.Beep(554, 250);
                Console.Beep(523, 125);
                Console.Beep(466, 125);
                Console.Beep(523, 250);
                Thread.Sleep(250);
                Console.Beep(349, 250);
                Console.Beep(415, 500);
                Console.Beep(349, 375);
                Console.Beep(523, 125);
                Console.Beep(440, 500);
                Console.Beep(349, 375);
                Console.Beep(261, 125);
                Console.Beep(440, 1000);
                Thread.Sleep(100); // Задержка 100 миллисекунд
            }
        }
    }
}
