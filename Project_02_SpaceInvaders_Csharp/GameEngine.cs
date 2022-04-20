using Project_02_SpaceInvaders_Csharp.GameObjectFactories;
using System;
using System.Threading;

namespace Project_02_SpaceInvaders_Csharp
{
    /// <summary>
    /// Class for calculating of the game scene.
    /// </summary>
    class GameEngine
    {
        /// <summary>
        /// Game over trigger.
        /// </summary>
        private bool _isNotOver;

        private static GameEngine _gameEngine;

        private SceneRender _sceneRender;

        private GameSettings _gameSettings;

        private Scene _scene;

        /// <summary>
        /// Alien ships destroyed.
        /// </summary>
        private int scoreAlienShips;

        /// <summary>
        /// Ground objects remained.
        /// </summary>
        private int scoreGroundObjects;


        // Keystroke triggers.

        /// <summary>
        /// Key P pressed.
        /// </summary>
        private bool isKeyPause;

        /// <summary>
        /// Key Esc pressed.
        /// </summary>
        private bool isKeyEscape;

        /// <summary>
        /// Key Enter pressed.
        /// </summary>
        public bool isKeyEnter;

        private GameEngine()
        {

        }

        private GameEngine(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _isNotOver = true;
            _scene = Scene.GetScene(gameSettings);
            _sceneRender = new SceneRender(gameSettings);

            isKeyPause = false;
            isKeyEscape = false;
            isKeyEnter = false;
        }

        public static GameEngine GetGameEngine(GameSettings gameSettings)
        {
            _gameEngine = new GameEngine(gameSettings);

            return _gameEngine;
        }

        /// <summary>
        /// Starting the game.
        /// </summary>
        public void Run()
        {
            int swarmMoveCounter = 0;
            int playerMissileCounter = 0;
            int bombCreatingCounter = 0;
            int bombCounter = 0;

            scoreAlienShips = 0;
            scoreGroundObjects = _gameSettings.NumberOfGroundRows * _gameSettings.NumberOfGroundCols;
            
            _sceneRender.ControlPanel();

            do
            {
                if (isKeyPause)
                {
                    continue;
                }
                if (isKeyEscape)
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
                if (isKeyEnter)
                {
                    break;
                }

                _sceneRender.Render(_scene);

                Thread.Sleep(_gameSettings.GameSpeed);

                _sceneRender.ClearScreen();

                
                // Moving alien sheps.
                if (swarmMoveCounter == _gameSettings.SwarmSpeed)
                {
                    CalculateSwarmMove();
                    swarmMoveCounter = 0;
                }

                swarmMoveCounter++;


                // Moving player missiles.
                if (playerMissileCounter == _gameSettings.PlayerMissileSpeed)
                {
                    CalculateMissileMove();
                    playerMissileCounter = 0;
                }

                playerMissileCounter++;


                // Randomly creating alien bombs.
                if (bombCreatingCounter == _gameSettings.AlienBombSpeedCreating)
                {
                    Bomb();
                    bombCreatingCounter = 0;
                }

                bombCreatingCounter++;


                // Moving alien bombs.
                if (bombCounter == _gameSettings.AlienBombSpeed)
                {
                    CalculateBombMove();
                    bombCounter = 0;
                }

                bombCounter++;


            } while (_isNotOver);

            Console.ForegroundColor = ConsoleColor.Red;
            _sceneRender.RenderGameOver();
            Console.ForegroundColor = ConsoleColor.Green;

            // Displaying the score on the screen.
            _sceneRender.GetScore(_gameSettings, scoreAlienShips, scoreGroundObjects);

            // Restore console Foreground Color by default.
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Moving the Player ship to the left.
        /// </summary>
        public void CalculateMovePlayerShipLeft()
        {
            if (_scene.playerShip.GameObjectPlace.XCoordinate > 1)
            {
                _scene.playerShip.GameObjectPlace.XCoordinate--;
            }
        }

        /// <summary>
        /// Moving the Player ship to the right.
        /// </summary>
        public void CalculateMovePlayerShipRight()
        {
            if (_scene.playerShip.GameObjectPlace.XCoordinate < _gameSettings.ConsoleWidth - 1)
            {
                _scene.playerShip.GameObjectPlace.XCoordinate++;
            }
        }

        /// <summary>
        /// Moving alien ships down.
        /// </summary>
        public void CalculateSwarmMove()
        {
            for (int i = 0; i < _scene.swarm.Count; i++)
            {
                GameObject alienShip = _scene.swarm[i];

                alienShip.GameObjectPlace.YCoordinate++;

                bool isGameOver = alienShip.GameObjectPlace.YCoordinate == _scene.playerShip.GameObjectPlace.YCoordinate;
                if (isGameOver)
                {
                    _isNotOver = false;
                }
            }
        }

        /// <summary>
        /// Shoot missiles.
        /// </summary>
        public void Shoot()
        {
            PlayerShipMissileFactory missileFactory = new PlayerShipMissileFactory(_gameSettings);

            GameObject missile = missileFactory.GetGameObject(_scene.playerShip.GameObjectPlace);

            _scene.playerShipMissile.Add(missile);

            Console.Beep(1000, 200);
        }

        /// <summary>
        /// Moving missiles.
        /// </summary>
        public void CalculateMissileMove()
        {
            // No missiles.
            if (_scene.playerShipMissile.Count == 0)
            {
                return;
            }

            // There are missiles.
            for (int x = 0; x < _scene.playerShipMissile.Count; x++)
            {
                GameObject missile = _scene.playerShipMissile[x];

                // The missile was out the screen.
                if (missile.GameObjectPlace.YCoordinate == 1)
                {
                    _scene.playerShipMissile.RemoveAt(x);
                }

                missile.GameObjectPlace.YCoordinate--;

                // The missile destroyed the alien ship.
                for (int i = 0; i < _scene.swarm.Count; i++)
                {
                    GameObject alienShip = _scene.swarm[i];

                    if (missile.GameObjectPlace.Equals(alienShip.GameObjectPlace))
                    {
                        _scene.swarm.RemoveAt(i);
                        _scene.playerShipMissile.RemoveAt(x);
                        scoreAlienShips++;
                        break;
                    }
                }

                // The missile destroyed the alien bomb.
                for (int i = 0; i < _scene.alienShipBomb.Count; i++)
                {
                    GameObject alienBomb = _scene.alienShipBomb[i];

                    if (missile.GameObjectPlace.Equals(alienBomb.GameObjectPlace))
                    {
                        _scene.alienShipBomb.RemoveAt(i);
                        _scene.playerShipMissile.RemoveAt(x);
                        Console.Beep(200, 200);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Randomly creating alien bombs.
        /// </summary>
        public void Bomb()
        {
            AlienShipBombFactory bombFactory = new AlienShipBombFactory(_gameSettings);

            Random random = new Random();
            int rand = random.Next(_scene.swarm.Count);
            GameObject bomb = bombFactory.GetGameObject(_scene.swarm[rand].GameObjectPlace);

            _scene.alienShipBomb.Add(bomb);
        }

        /// <summary>
        /// Moving alien bombs down.
        /// </summary>
        public void CalculateBombMove()
        {
            // No bombs.
            if (_scene.alienShipBomb.Count == 0)
            {
                return;
            }

            // There are bombs.
            for (int x = 0; x < _scene.alienShipBomb.Count; x++)
            {
                GameObject bomb = _scene.alienShipBomb[x];

                // // The bomb was out the screen.
                if (bomb.GameObjectPlace.YCoordinate == _gameSettings.ConsoleHeight - 1)
                {
                    _scene.alienShipBomb.RemoveAt(x);
                }

                bomb.GameObjectPlace.YCoordinate++;

                // The bomb destroyed the player ship.
                bool isGameOver = _scene.alienShipBomb[x].GameObjectPlace.Equals(_scene.playerShip.GameObjectPlace);
                if (isGameOver)
                {
                    _isNotOver = false;
                }

                // Bombs destroyed Ground Objects.
                for (int i = 0; i < _scene.ground.Count; i++)
                {
                    GameObject groundObj = _scene.ground[i];

                    if (bomb.GameObjectPlace.Equals(groundObj.GameObjectPlace))
                    {
                        _scene.ground.RemoveAt(i);
                        _scene.alienShipBomb.RemoveAt(x);
                        scoreGroundObjects--;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Game pause.
        /// </summary>
        public void PauseGame()
        {
            isKeyPause = !isKeyPause;
        }

        /// <summary>
        /// Exit from the game
        /// </summary>
        public void ExitGame()
        {
            isKeyEscape = !isKeyEscape;
        }

        /// <summary>
        /// Game start or restart.
        /// </summary>
        public void StartGame()
        {
            isKeyEnter = !isKeyEnter;
        }
    }
}
