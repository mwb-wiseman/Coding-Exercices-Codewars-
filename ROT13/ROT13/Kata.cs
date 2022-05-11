using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROT13
{
    public class Kata
    {
        public static string Rot13(string input)
        {
            List<char> decodedOutput = new List<char>();

            if(input.Length > 0)
            {
                foreach (char c in input)
                {
                    if (Char.IsLetter(c))
                    {
                        decodedOutput.Add(DecodeRot13(Char.ToLower(c), Char.IsUpper(c)));
                    }
                    else
                    {
                        decodedOutput.Add(c);
                    }
                }
            }

            return String.Join("", decodedOutput);
        }

        public static char DecodeRot13(char c, bool caps)
        {
            char result = '\0';
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            Dictionary<char, int> dLetterNumber = new Dictionary<char, int>();
            Dictionary<int, char> dNumberLetter = new Dictionary<int, char>();

            for (int i = 0; i < alphabet.Length; i++)
            {
                dLetterNumber.Add(alphabet[i], i);
            }

            for (int i = 0; i < alphabet.Length; i++)
            {
                dNumberLetter.Add(i, alphabet[i]);
            }

            dLetterNumber.TryGetValue(c, out int letterCode);

            int decodedLetterKey = letterCode + 13;

            if(decodedLetterKey < alphabet.Length)
            {
                dNumberLetter.TryGetValue(decodedLetterKey, out char decodedLetter);
                result = decodedLetter;
            }
            else if(decodedLetterKey >= alphabet.Length)
            {
                dNumberLetter.TryGetValue(decodedLetterKey - alphabet.Length, out char decodedLetter);
                result = decodedLetter;
            }

            if (caps)
            {
                result = Char.ToUpper(result);
            }

            return result;
        }
    }
}
