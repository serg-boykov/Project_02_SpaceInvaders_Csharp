namespace Project_02_SpaceInvaders_Csharp
{
    /// <summary>
    /// Game object.
    /// </summary>
    abstract class GameObject
    {
        /// <summary>
        /// Game object location.
        /// </summary>
        public GameObjectPlace GameObjectPlace { get; set; }

        /// <summary>
        /// Game object symbol.
        /// </summary>
        public char Figure { get; set; }

        /// <summary>
        /// Game object type.
        /// </summary>
        public GameObjectType GameObjectType { get; set; }
    }
}
