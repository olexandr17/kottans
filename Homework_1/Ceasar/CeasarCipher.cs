using System;
using System.Linq;
using System.Text;

namespace Ceasar
{
    public class CeasarCipher
    {

        public char[] Abc { get; private set; }
        public int Offset { get; private set; }

        public CeasarCipher(int offset)
        {
            char abcStart = (char)0;
            char abcEnd = (char)127;

            Abc = new char[abcEnd - abcStart + 1];

            for (int i = 0; i < Abc.Length; i++)
            {
                Abc[i] = (char)(abcStart + i);
            }

            Offset = offset % Abc.Length;
        }

        public CeasarCipher(char[] abc, int offset)
        {
            if (abc == null)
            {
                throw new ArgumentNullException();
            }

            Abc = abc;
            Offset = offset % Abc.Length;
        }

        public string Encrypt(string str)
        {
            return shift(str, Offset);
        }

        public string Decrypt(string str)
        {
            return shift(str, -Offset);
        }


        private string shift(string str, int offset)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }   

            StringBuilder res = new StringBuilder();
            foreach (char ch in str)
            {
                if (!Abc.Contains(ch) || char.IsControl(ch))
                {
                    throw new ArgumentOutOfRangeException(); 
                }
                else
                {
                    res.Append(shift(ch, offset));
                }
            }

            return res.ToString();
        }

        private char shift(char ch, int offset)
        {
            if (char.IsWhiteSpace(ch))
            {
                return ch;
            }

            char res;

            do
            {
                int pos = Array.IndexOf(Abc, ch);
                pos = (pos + offset + Abc.Length) % Abc.Length;

                res = Abc[pos];

                offset += offset > 0 ? 1 : -1;
            }
            while (char.IsControl(res) || char.IsWhiteSpace(res));

            return res;
        }

    }
}
