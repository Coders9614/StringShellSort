using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringShellSort
{
    public class Solution
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            char[] sArray = s.ToCharArray();
            char[] tArray = t.ToCharArray();

            ShellSort(sArray);
            ShellSort(tArray);

            for (int i = 0; i < sArray.Length; i++)
            {
                if (sArray[i] != tArray[i])
                {
                    return false;
                }
            }

            return true;
        }

        private void ShellSort(char[] array)
        {
            int n = array.Length;
            int gap = n / 2;

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    char temp = array[i];
                    int j;
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }
                    array[j] = temp;
                }
                gap /= 2;
            }
        }

        public static void Main(string[] args)
        {
            Solution solution = new Solution();

            // Example 1
            string s1 = "anagram";
            string t1 = "nagaram";
            bool result1 = solution.IsAnagram(s1, t1);
            Console.WriteLine($"Input: s = \"{s1}\", t = \"{t1}\"");
            Console.WriteLine($"Output: {result1}");

            // Example 2
            string s2 = "rat";
            string t2 = "car";
            bool result2 = solution.IsAnagram(s2, t2);
            Console.WriteLine($"Input: s = \"{s2}\", t = \"{t2}\"");
            Console.WriteLine($"Output: {result2}");
            Console.ReadKey();
        }
    }
}
