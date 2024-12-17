namespace ALBRIGHT_ASSIGNMENT_7_2
{
    internal class Program
    {

        // MSSA CCAD16 - 17DEC2024
        // CHRIS ALBRIGHT
        // ASSIGNMENT 7.2 - WEEK 7
        static void Main(string[] args)
        {
            //Assignment 7.2.1.---------------------------------------------------------------------------------------------

            // Implement shell sort on an unsorted array of numbers. Take the array input from user.

            Console.WriteLine("Assignment 7.2.1: ---------------------------------------------------------------------");
            Console.WriteLine("SHELL SORTER:");
            char hold1 = 'y';
            do
            {
                Console.WriteLine("\nEnter the length of your integer array:");
                int n = Convert.ToInt32(Console.ReadLine());
                int[] array = new int[n];
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Enter the value for element {i+1}: ");
                    array[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("\nUnsorted array:");
                Console.Write("[ ");
                foreach (int var in array)
                {
                    Console.Write($"{var}, ");
                }
                Console.Write("]");
                ShellSort(array, n);
                Console.WriteLine("\n\nShell sorted array:");
                Console.Write("[ ");
                foreach (int var in array)
                {
                    Console.Write($"{var}, ");
                }
                Console.Write("]");
                Console.WriteLine($"\n\nWant to run 7.2.1 again? type y/n");
                hold1 = Console.ReadKey().KeyChar;
                hold1 = Char.ToLower(hold1);
            }
            while (hold1 == 'y');

            //Assignment 7.2.2.---------------------------------------------------------------------------------------------

            // Given a string s, reverse only all the vowels in the string and return it.

            Console.WriteLine("\n\n\nAssignment 7.2.2: ---------------------------------------------------------------------");
            Console.WriteLine("STRING VOWEL REVERSER:");
            char hold2 = 'y';
            do
            {
                Console.WriteLine("\nEnter a string for vowel reversing:");
                string s = Console.ReadLine();
                Console.WriteLine($"\nYour original string is: '{s}'");
                string result = VowelReverser(s);
                Console.WriteLine($"\nYour vowel reversed string is: '{result}'");
                Console.WriteLine($"\nWant to run 7.2.2 again? type y/n");
                hold2 = Console.ReadKey().KeyChar;
                hold2 = Char.ToLower(hold2);
            }
            while (hold2 == 'y');

            //Assignment 7.2.3.---------------------------------------------------------------------------------------------

            // Given two strings s1 and s2, return true if s1 is an anagram of s2, and false otherwise.

            Console.WriteLine("\n\n\nAssignment 7.2.3: ---------------------------------------------------------------------");
            Console.WriteLine("ANAGRAM CHECKER:");
            char hold3 = 'y';
            do
            {
                Console.WriteLine("\nEnter string 1:");
                string s1 = Console.ReadLine();
                s1 = s1.ToLower();
                Console.WriteLine("\nEnter string 2:");
                string s2 = Console.ReadLine();
                s2 = s2.ToLower();
                Console.WriteLine($"\nS1: '{s1}', S2: '{s2}'");
                Console.Write($"\nAnagram checker says: {IsAnagram(s1,s2)}");
                Console.WriteLine($"\n\nWant to run 7.2.3 again? type y/n");
                hold3 = Console.ReadKey().KeyChar;
                hold3 = Char.ToLower(hold3);
            }
            while (hold3 == 'y');

            Console.WriteLine("\n\nGoodbye!");
        }
        //-------------------------------------------------Methods-----------------------------------------------------------
        public static int[] ShellSort (in int[] array, int n)
        {
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int j = i;
                    int temp = array[i];
                    while ( j >= gap && array[j - gap] > temp)
                    {
                        array[j] = array[j - gap];
                        j -= gap;  
                    }
                    array[j] = temp;
                }
            }
            return array;
        }
        public static string VowelReverser(string s)
        {
            HashSet<char> vowels = new HashSet<char> { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U'};
            char[] charArray = s.ToCharArray();
            int leftPointer = 0;
            int rightPointer = s.Length - 1;
            while (leftPointer < rightPointer)
            {
                if (!vowels.Contains(charArray[leftPointer]))
                {
                    leftPointer++;
                    continue;
                }
                if (!vowels.Contains(charArray[rightPointer]))
                {
                    rightPointer--;
                    continue;
                }
                char temp = charArray[leftPointer];
                charArray[leftPointer] = charArray[rightPointer];
                charArray[rightPointer] = temp;
                leftPointer++;
                rightPointer--;
            }
            string result = new string(charArray);  
            return result;
        }
        public static bool IsAnagram(in string s1, in string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (char c in s1)
            {
                if (map.ContainsKey(c))
                {
                    map[c]++;
                }
                else
                {
                    map[c] = 1;
                }
            }
            foreach (char c in s2)
            {
                if (map.ContainsKey(c))
                {
                    map[c]--;
                }
                else
                {
                    map[c] = -1;
                }
            }
            bool AllZeros = map.Values.All(value => value == 0);
            return AllZeros;
        }
    }
}
