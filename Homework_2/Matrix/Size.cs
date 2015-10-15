namespace Matrix
{
    public struct Size
    {

        public static bool operator ==(Size a, Size b)
        {
            return a.Height == b.Height && a.Width == b.Width;
        }

        public static bool operator !=(Size a, Size b)
        {
            return !(a == b);
        }


        public int Height;
        public int Width;

        public bool IsSquare { get { return Height == Width; } }


        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }


        public override bool Equals(object obj)
        {
            if (obj is Size)
            {
                return this == (Size)obj;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
