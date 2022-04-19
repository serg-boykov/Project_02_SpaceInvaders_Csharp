using Project_02_SpaceInvaders_Csharp.GameObjectFactories;
using System;
using System.Threading;

namespace Project_02_SpaceInvaders_Csharp
{
    class GameEngine
    {
        private bool _isNotOver;

        private static GameEngine _gameEngine;

        private SceneRender _sceneRender;

        private GameSettings _gameSettings;

        private Scene _scene;

        private int scoreAlienShips;
        private int scoreGroundObjects;

        private bool isKeyPause;
        private bool isKeyEscape;
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

                if (swarmMoveCounter == _gameSettings.SwarmSpeed)
                {
                    CalculateSwarmMove();
                    swarmMoveCounter = 0;
                }

                swarmMoveCounter++;

                if (playerMissileCounter == _gameSettings.PlayerMissileSpeed)
                {
                    CalculateMissileMove();
                    playerMissileCounter = 0;
                }

                playerMissileCounter++;


                if (bombCreatingCounter == _gameSettings.AlienBombSpeedCreating)
                {
                    Bomb();
                    bombCreatingCounter = 0;
                }

                bombCreatingCounter++;


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
            _sceneRender.GetScore(_gameSettings, scoreAlienShips, scoreGroundObjects);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void CalculateMovePlayerShipLeft()
        {
            if (_scene.playerShip.GameObjectPlace.XCoordinate > 1)
            {
                _scene.playerShip.GameObjectPlace.XCoordinate--;
            }
        }

        public void CalculateMovePlayerShipRight()
        {
            if (_scene.playerShip.GameObjectPlace.XCoordinate < _gameSettings.ConsoleWidth - 1)
            {
                _scene.playerShip.GameObjectPlace.XCoordinate++;
            }
        }

        public void CalculateSwarmMove()
        {
            for (int i = 0; i < _scene.swarm.Count; i++)
            {
                GameObject alienShip = _scene.swarm[i];

                alienShip.GameObjectPlace.YCoordinate++;

                if (alienShip.GameObjectPlace.YCoordinate == _scene.playerShip.GameObjectPlace.YCoordinate)
                {
                    _isNotOver = false;
                }
            }
        }

        public void Shoot()
        {
            PlayerShipMissileFactory missileFactory = new PlayerShipMissileFactory(_gameSettings);

            GameObject missile = missileFactory.GetGameObject(_scene.playerShip.GameObjectPlace);

            _scene.playerShipMissile.Add(missile);

            Console.Beep(1000, 200);
        }

        public void CalculateMissileMove()
        {
            if (_scene.playerShipMissile.Count == 0)
            {
                return;
            }

            for (int x = 0; x < _scene.playerShipMissile.Count; x++)
            {
                GameObject missile = _scene.playerShipMissile[x];

                if (missile.GameObjectPlace.YCoordinate == 1)
                {
                    _scene.playerShipMissile.RemoveAt(x);
                }

                missile.GameObjectPlace.YCoordinate--;

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

        public void Bomb()
        {
            AlienShipBombFactory bombFactory = new AlienShipBombFactory(_gameSettings);

            Random random = new Random();
            int rand = random.Next(_scene.swarm.Count);
            GameObject bomb = bombFactory.GetGameObject(_scene.swarm[rand].GameObjectPlace);

            _scene.alienShipBomb.Add(bomb);
        }

        public void CalculateBombMove()
        {
            if (_scene.alienShipBomb.Count == 0)
            {
                return;
            }

            for (int x = 0; x < _scene.alienShipBomb.Count; x++)
            {
                GameObject bomb = _scene.alienShipBomb[x];

                if (bomb.GameObjectPlace.YCoordinate == _gameSettings.ConsoleHeight - 1)
                {
                    _scene.alienShipBomb.RemoveAt(x);
                }

                bomb.GameObjectPlace.YCoordinate++;

                if (_scene.alienShipBomb[x].GameObjectPlace.Equals(_scene.playerShip.GameObjectPlace))
                {
                    _isNotOver = false;
                }

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

        public void PauseGame()
        {
            isKeyPause = !isKeyPause;
        }

        public void ExitGame()
        {
            isKeyEscape = !isKeyEscape;
        }

        public void StartGame()
        {
            isKeyEnter = !isKeyEnter;
        }
    }
}
