namespace Perdition.scripts {
    
    /// <summary>
    /// vector with 2 integer components
    /// </summary>
    public struct Vector2i {
        
        /// <summary>
        /// creates a new <see cref="Vector2i"/>
        /// </summary>
        /// <param name="x">value for x component</param>
        /// <param name="y">value for y component</param>
        public Vector2i(int x, int y) {
            X = x;
            Y = y;
        }

        /// <summary>
        /// x component
        /// </summary>
        public int X { get; }
        
        /// <summary>
        /// y component
        /// </summary>
        public int Y { get; }

    }
}