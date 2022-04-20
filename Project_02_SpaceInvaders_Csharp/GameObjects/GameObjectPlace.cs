namespace Project_02_SpaceInvaders_Csharp
{
    /// <summary>
    /// Game object location.
    /// </summary>
    class GameObjectPlace
    {
        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        /// <summary>
        /// Comparison of objects by coordinates.
        /// </summary>
        /// <param name="obj">Other object.</param>
        /// <returns>True or False.</returns>
        public override bool Equals(object obj)
        {
            GameObjectPlace other = obj as GameObjectPlace;

            if (other == null) return false;
            return other.XCoordinate == XCoordinate && other.YCoordinate == YCoordinate;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
