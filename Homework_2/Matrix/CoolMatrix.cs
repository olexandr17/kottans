using System;

namespace Matrix
{
    public class CoolMatrix
    {

        public static implicit operator CoolMatrix(int[,] arr)
        {
            return new CoolMatrix(arr);
        }

        public static implicit operator int[,] (CoolMatrix matrix)
        {
            return (int[,])matrix.values.Clone();
        }


        public static bool operator ==(CoolMatrix a, CoolMatrix b)
        {
            if (Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (a.Size != b.Size)
            {
                return false;
            }

            for (int i = 0; i < a.Size.Width; i++)
            {
                for (int j = 0; j < a.Size.Height; j++)
                {
                    if (a.values[i, j] != b.values[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator !=(CoolMatrix a, CoolMatrix b)
        {
            return !(a == b);
        }


        public static CoolMatrix operator +(CoolMatrix a, CoolMatrix b)
        {
            if (a.Size != b.Size)
            {
                throw new ArgumentException();
            }

            var res = new CoolMatrix(new int[a.Size.Width, a.Size.Height]);

            for (int i = 0; i < a.Size.Width; i++)
            {
                for (int j = 0; j < a.Size.Height; j++)
                {
                    res.values[i, j] = a.values[i, j] + b.values[i, j];
                }
            }

            return res;
        }

        public static CoolMatrix operator +(CoolMatrix a, int b)
        {
            var res = new CoolMatrix(new int[a.Size.Width, a.Size.Height]);

            for (int i = 0; i < a.Size.Width; i++)
            {
                for (int j = 0; j < a.Size.Height; j++)
                {
                    res.values[i, j] = a.values[i, j] + b;
                }
            }

            return res;
        }

        public static CoolMatrix operator *(CoolMatrix a, CoolMatrix b)
        {
            if (a.Size != b.Size)
            {
                throw new ArgumentException();
            }

            var res = new CoolMatrix(new int[a.Size.Width, a.Size.Height]);

            for (int i = 0; i < a.Size.Width; i++)
            {
                for (int j = 0; j < a.Size.Height; j++)
                {
                    res.values[i, j] = a.values[i, j] * b.values[i, j];
                }
            }

            return res;
        }

        public static CoolMatrix operator *(CoolMatrix a, int b)
        {
            var res = new CoolMatrix(new int[a.Size.Width, a.Size.Height]);

            for (int i = 0; i < a.Size.Width; i++)
            {
                for (int j = 0; j < a.Size.Height; j++)
                {
                    res.values[i, j] = a.values[i, j] * b;
                }
            }

            return res;
        }


        private readonly int[,] values;

        public Size Size { get; }

        public bool IsSquare { get { return Size.IsSquare; } }


        public int this[int x, int y]
        {
            get { return values[x, y]; }
            set { values[x, y] = value; }
        }

        public CoolMatrix(int[,] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }

            Size = new Size(arr.GetLength(0), arr.GetLength(1));
            values = arr;
        }

        public CoolMatrix Transpose()
        {
            var res = new CoolMatrix(new int[Size.Height, Size.Width]);

            for (int i = 0; i < Size.Width; i++)
            {
                for (int j = 0; j < Size.Height; j++)
                {
                    res.values[j, i] = this[i, j];
                }
            }

            return res;
        }


        public override string ToString()
        {
            var cols = new string[Size.Height];
            for (int i = 0; i < Size.Height; i++)
            {
                var row = new int[Size.Width];
                for (int j = 0; j < Size.Width; j++)
                {
                    row[j] = this[i, j];
                }
                cols[i] = $"[{String.Join(", ", row)}]";
            }

            return String.Join(Environment.NewLine, cols);
        }

        public override bool Equals(object obj)
        {
            if (obj is CoolMatrix)
            {
                return this == (CoolMatrix)obj;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
