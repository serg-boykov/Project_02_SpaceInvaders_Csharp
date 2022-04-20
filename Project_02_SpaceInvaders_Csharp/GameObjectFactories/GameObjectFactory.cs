namespace Project_02_SpaceInvaders_Csharp.GameObjectFactories
{
    /// <summary>
    /// Game object factory.
    /// </summary>
    abstract class GameObjectFactory
    {
        public GameSettings GameSettings { get; set; }

        public GameObjectFactory(GameSettings gameSettings)
        {
            GameSettings = gameSettings;
        }

        /// <summary>
        /// Creating a new game object in the place on the screen.
        /// </summary>
        /// <param name="objectPlace">The place on the screen.</param>
        /// <returns>The new game object.</returns>
        public abstract GameObject GetGameObject(GameObjectPlace objectPlace);
    }
}
