namespace Day2
{
    public class Vector2I
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2I()
        {
            X = 0;
            Y = 0;
        }

        public Vector2I(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return X + "," + Y;
        }

        public static Vector2I operator +(Vector2I a, Vector2I b)
        {
            return new Vector2I(a.X + b.X, a.Y + b.Y);
        }
    }
}
