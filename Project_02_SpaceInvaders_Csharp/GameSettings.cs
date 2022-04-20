namespace Project_02_SpaceInvaders_Csharp
{
    /// <summary>
    /// Game Settings.
    /// </summary>
    class GameSettings
    {
        public int ConsoleWidth { get; set; } = 80;

        public int ConsoleHeight { get; set; } = 33;

        public int ConsoleCtrlPanelHeight { get; set; } = 8;
        //------------------------------------------

        public int NumberOfSwarmRows { get; set; } = 2;

        public int NumberOfSwarmCols { get; set; } = 60;


        public int SwarmStartXCoordinate { get; set; } = 10;

        public int SwarmStartYCoordinate { get; set; } = 2;


        public char AlienShip { get; set; } = 'O';

        public int SwarmSpeed { get; set; } = 200;
        //------------------------------------------

        public int PlayerShipStartXCoordinate { get; set; } = 40;

        public int PlayerShipStartYCoordinate { get; set; } = 19;

        public char PlayerShip { get; set; } = '^';
        //------------------------------------------

        public int GroundStartXCoordinate { get; set; } = 0;

        public int GroundStartYCoordinate { get; set; } = 20;


        public char Ground { get; set; } = 'U';

        public int NumberOfGroundRows { get; set; } = 1;

        public int NumberOfGroundCols { get; set; } = 80;
        //------------------------------------------

        public char PlayerMissile { get; set; } = '|';

        public int PlayerMissileSpeed { get; set; } = 5;
        //------------------------------------------
        
        public char AlienBomb { get; set; } = '*';

        public int AlienBombSpeed { get; set; } = 50;

        public int AlienBombSpeedCreating { get; set; } = 100;
        //------------------------------------------

        public int GameSpeed { get; set; } = 5;
    }
}

/*            1         2         3         4         5         6         7         8
 *  012345678901234567890123456789012345678901234567890123456789012345678901234567890 = ConsoleWidth = X
 *  1
 *  2         OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO = 60
 *  3         OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO = 60
 *  4         ||
 *  5         2
 *  6
 *  7
 *  8
 *  9
 * 10
 * 11
 * 12
 * 13
 * 14
 * 15
 * 16
 * 17
 * 18
 * 19                                           ^
 * 20UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU
 *  012345678901234567890123456789012345678901234567890123456789012345678901234567890 = ConsoleWidth = X
 *            1         2         3         4         5         6         7         8
 * 23 ||
 * 24 Console Height
 * 25 ||
 * 26 Y
 * 27
 * 28
 * 29
 * 30
 */
