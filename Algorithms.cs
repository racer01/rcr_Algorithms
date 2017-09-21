using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Algorithms
{
    internal class Algorithms : IAlgorithms
    {
        public object[][] ChunkArrayInGroups(object[] numbers, int counter)
        {
            int resultX = (int)Math.Ceiling((double)numbers.Length / counter);
            object[][] result = new object[resultX][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = numbers
                    .Skip(i * counter)
                    .Take(counter)
                    .ToArray();
            }
            return result;
        }

        public bool ConfirmEnding(string word, string end)
        {
            return Regex.IsMatch(word, string.Format("{0}$", end));
        }

        public object[] Destroyer(object[] numbers, params object[] obj)
        {
            return numbers.Where(n => !obj.Contains(n)).ToArray();
        }

        public long Factorialize(int number)
        {
            long val = 1;
            while (number > 1)
            {
                val *= number;
                number--;
            }
            return val;
        }

        public int FindLongestWord(string word)
        {
            return word.Split(' ').Max(w => w.Length);
        }

        public int GetIndexToIns(object[] numbers, float number)
        {
            var numberList = numbers.ToList();
            numberList.Sort();
            numbers = numberList.ToArray();
            if (number <= (int)numbers[0])
                return 0;
            for (int i = 1; i < numbers.Length ; i++)
            {
                object before = numbers[i - 1];
                object after = numbers[i];
                if ((int)before < number && number <= (int)after)
                {
                    return i;
                }
            }
            return numbers.Length;
        }

        public int[] LargestOfFour(int[][] numbers)
        {
            return numbers.Select(arr => arr.Max()).ToArray();
        }

        public bool Palindrome(string word)
        {
            word = Regex.Replace(word, @"[^A-Za-z0-9]", "", RegexOptions.IgnoreCase);
            int halfLen = (int)Math.Ceiling(word.Length / 2f);
            string first = word.Substring(0, halfLen);
            string last = new string(word.Reverse().ToArray()).Substring(0, halfLen);
            return first.Equals(last, StringComparison.InvariantCultureIgnoreCase);
        }

        public string RepeatStringNumTimes(string word, int counter)
        {
            return string.Concat(Enumerable.Repeat(word, Math.Max(0, counter)));
        }

        public string ReverseString(string word)
        {
            return new string(word.ToCharArray().Reverse().ToArray());
        }

        public string Rot13(string word)
        {
            return new string(word.ToUpper().Select(c =>
                Regex.IsMatch(c.ToString(), "[A-Z]")
                ? ((c - 13) >= 'A' ? (char)(c - 13) : (char)(c - 13 + ('Z' - 'A') + 1))
                : c).ToArray());
        }

        public object[] Slasher(object[] numbers, int counter)
        {
            return numbers.Skip(counter - 1).ToArray();
        }

        public string TitleCase(string word)
        {
            return string.Join(" ", word.Split(' ')
                .Select(w =>
                    Regex.Replace(w.ToLower(), "^.", fc =>
                        fc.ToString().ToUpper()))
                .ToArray());
        }

        public string TruncateString(string word, int counter)
        {
            return word.Length > counter
                ? word.Substring(0, counter > 3 ? counter - 3 : counter) + "..."
                : word;
        }
    }
}