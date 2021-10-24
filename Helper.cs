using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bilgi_Sistemleri_3._Hafta_Password_Generator
{
    public class Helpers
    {
        public static void GeneratePassword(string input)
        {
            var inputStringArray = input.Split(",");
            string duplicatedChars = String.Empty;
            foreach (var s in inputStringArray)
            {
                duplicatedChars += s;
            }

            string chars = new string(duplicatedChars.ToCharArray().Distinct().ToArray());
            char[] current = new char[chars.Length];
            List<string> perms = new List<string>();
            string path = @"C:\Users\BERKAY\Desktop\şifreler.txt";
            for (int n = 5; n <= 5; ++n)
                BuildPermutations(chars, current, 0, n, perms);
            using (var sw = new StreamWriter(path))
            {
                foreach (string s in perms)
                {
                    Console.WriteLine(s);
                    sw.WriteLine(s);
                }
            }
        }
        private static void BuildPermutations(string input, char[] current, int index, int depth, List<string> perms)
        {
            if (index == depth)
            {
                perms.Add(new string(current, 0, depth));
                return;
            }
            for (int n = 0; n < input.Length; ++n)
            {
                current[index] = input[n];
                BuildPermutations(input, current, index + 1, depth, perms);
            }
        }

    }
}