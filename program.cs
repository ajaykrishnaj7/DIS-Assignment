/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System;
using System.Collections.Generic;
using System.Linq;///for List
using System.Collections;//for Stack
using System.Text;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partition lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int length = nums.Length;
                int lowest, highest;       // Declaring variables for Boundary
                lowest = 0; // Initilizing lowest boundary
                highest = length - 1; // Assigning highest boundary
                int midValue = (lowest + highest) / 2;         // Mid value calculation
                while (lowest <= highest)
                {       // boundary condition for BS
                    if (nums[midValue] == target)         // if target found, returning the index
                        return midValue;
                    if (nums[midValue] < target)          // if not, trimming the search space 
                        lowest = midValue + 1;
                    else if (nums[midValue] > target)
                        highest = midValue - 1;
                    midValue = (lowest + highest) / 2;            // updating the mid value
                }
                if (nums[midValue] < target)          // if the element is not in the given array and if the mid value is less then we return lowest
                    return lowest;
                return highest;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.

        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"] 
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.

        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {

                paragraph = paragraph.ToLower();            // Removing all spaces and making all letters lowercase
                paragraph = paragraph.Replace(".", "");
                paragraph = paragraph.Replace(",", "");

                string[] words = paragraph.Split();         // splitting string to array

                // dictionary for mapping words to their frequency in the paragraph
                Dictionary<string, int> dic = new Dictionary<string, int>();

                for (int i = 0; i < words.Length; i++)      // iterating through dictionary
                {
                    if (Array.IndexOf(banned, words[i]) == -1)      // if not a banned word,
                    {
                        if (dic.ContainsKey(words[i]) == true)     // increasing frequency in dictionary
                            dic[words[i]] += 1;
                        else
                            dic.Add(words[i], 1);
                    }
                }

                int max = -1;
                string str = "";
                foreach (KeyValuePair<string, int> k in dic)  // for all ks in dictionary,
                {
                    if (k.Value >= max)         // checking for the maximum value key.
                    {
                        str = k.Key;
                        max = k.Value;
                    }
                }
                return str;     // returning the maximum frequent word which is not in banned array
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.

        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.

        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                Dictionary<int, int> dic = new Dictionary<int, int>(); // dictionary for mapping integers to their frequency in an array.

                for (int i = 0; i < arr.Length; i++)
                {
                    if (dic.ContainsKey(arr[i]) == true)  // if found in dictionary
                        dic[arr[i]] += 1; // updating the dictionary
                    else
                        dic.Add(arr[i], 1); // if not upading the dictionary accordingly
                }

                int k = -1;
                foreach (KeyValuePair<int, int> kv in dic) // iterating through the dictionary
                {   
                    if (kv.Value == kv.Key)
                    {         
                        if (k < kv.Key) // if it's a lucky number, and greater one than prev lucky number
                            k = kv.Key; // updating 
                    }
                }
                return k;       // returning the number
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"

        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                // dictionary for mapping chars to their frequency in the string
                Dictionary<char, int> dic = new Dictionary<char, int>();

                for (int i = 0; i < secret.Length; i++) // iterating through
                {       // performs the same
                    if (dic.ContainsKey(secret[i]) == true) // i found in dictionary
                        dic[secret[i]] += 1; // upading the dictionary
                    else
                        dic.Add(secret[i], 1); // if not updating accordingly
                }

                int bulls = 0;
                int cows = 0;
                for (int i = 0; i < secret.Length; i++)
                {            // calculate the number of bulls: if same character in both strings ( check in dictionary), then increasing bulls
                    if (secret[i] == guess[i])
                    {
                        bulls++;
                        dic[guess[i]] -= 1;      // decreasing count 
                    }
                }
                for (int i = 0; i < secret.Length; i++)
                {             // calculate cows: if the char present in main string(check in dict) but not in place, then increment cows
                    if (secret[i] != guess[i])
                    {
                        if (dic.ContainsKey(guess[i]) == true)
                        {
                            if (dic[guess[i]] > 0)
                                cows++;
                        }
                    }
                }
                string res = bulls.ToString() + "A" + cows.ToString() + "B";        // formatting result
                return res; // returning the result
            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.

        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.

        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                List<int> l = new List<int>();

                int index = 0;        // initialising index

                int i = 0;
                // dictionary for mapping chars to their last known position
                Dictionary<char, int> dict = new Dictionary<char, int>();
                int prev = 0;  // previous known partition index
                while (i < s.Length)
                {
                    char par = s[i];  // storing the first char in this partition
                    for (int j = i; j < s.Length; j++)
                    {
                        if (dict.ContainsKey(s[j]) == true)
                        {    // if key is there,
                            if (s[j] == par || dict[s[j]] <= index)        // if it is the first character, or the character already in this partition,
                                index = j;        // updating the index

                            dict[s[j]] = j;     // updating dictionary
                        }
                        else
                        {                // if not updating the dictionary accordingly
                            dict.Add(s[j], j);
                        }
                    }
                    int entry = index + 1;

                    if (i != 0)
                    {
                        entry = entry - prev;           // calcs the size of the partition
                    }
                    l.Add(entry);        // add to list

                    i = index + 1;        // update i to last index of the partition
                    prev = index + 1;
                }
                return l; // returning the list

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6

        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.



         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.

         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                // Initializing the integers required
                Int32 row = 1; 
                Int32 sum = 0;
                Int32 temp = 0;

                Char[] c = s.ToCharArray();
                foreach (Char _c in c) // iterating through array
                {
                    temp = widths[_c - 97];
                    if (sum + temp > 100) // if greater than 100
                    {
                        row++;
                        sum = temp; // updating the sum
                    }
                    else
                    {
                        sum += temp; // if not updating the sum accordingly
                    }
                }

                return new List<int> { row, sum }; // returning the row and sum as list
            }
            catch (Exception)
            {
                throw;
            }

        }


        /*
        
        Question 7:

        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true

        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true

        Example 3:
        Input: bulls_string  = "(]"
        Output: false

        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                Stack<char> s = new Stack<char>();
                //iterating through all characters
                for (int i = 0; i < bulls_string10.Length; i++)
                {
                    //  Pushing into stack  if the symbol is open                               
                    if (bulls_string10[i] == '(' || bulls_string10[i] == '{' || bulls_string10[i] == '[')
                    {
                        s.Push(bulls_string10[i]);
                    }
                    // pulling from stack  if the symbol is close
                    if (bulls_string10[i] == ')' || bulls_string10[i] == '}' || bulls_string10[i] == ']')
                    {
                        if (s.Count <= 0)
                        {
                            return false;
                        }
                        if (bulls_string10[i] == ')') // if close
                        {
                            if (s.Peek() == '(') // if open
                            {
                                s.Pop(); //popping it out
                            }
                            else
                            {
                                return false;
                            }
                        }
                        if (bulls_string10[i] == '}') // if close curly brace
                        {
                            if (s.Peek() == '{') // if open curly brace
                            {
                                s.Pop(); // opping it out
                            }
                            else
                            {
                                return false;
                            }
                        }
                        if (bulls_string10[i] == ']') // if  closed square bracket
                        {
                            if (s.Peek() == '[') // if poen square bracket
                            {
                                s.Pop(); // opping it out
                            }
                            else
                            {
                                return false;
                            }
                        }

                    }
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }


        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.

        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".

        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                string[] morse = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };

                //declaring hash set for storing unique values
                var dic = new HashSet<string>();

                foreach (var word in words) // iterating through words
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var l in word)
                    {
                        // Converting the char to morse and generating the string
                        sb.Append(morse[(int)l - 97]);
                    }

                    //Check if it already has
                    if (!dic.Contains(sb.ToString()))
                    {
                        dic.Add(sb.ToString());
                    }
                }
                //return the Count
                return dic.Count;
            }
            catch (Exception)
            {
                throw;
            }

        }




        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).

        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.

        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
                // initializing the integers with square root and maximum and etc.,
                int n = Convert.ToInt32(Math.Sqrt(Convert.ToDouble(grid.Length)));
                int l = Math.Max(grid[0,0], grid[n - 1,n - 1]);
                int h = n * n - 2;
                bool[] visited = null;
                while (l <= h) // low value less than or equal to high
                {
                    int mid = l + (h - l) / 2;
                    visited = new bool[n * n];
                    var success = Dfs(mid, 0, 0);
                    if (success)
                        h = mid - 1;
                    else
                        l = mid + 1;
                }
                return l;

                bool Dfs(int t, int y, int x)
                {
                    if (x == n - 1 && y == n - 1)
                        return true;

                    visited[grid[y,x]] = true;

                    // down
                    if (y + 1 < n && !visited[grid[y + 1,x]] && grid[y + 1,x] <= t && Dfs(t, y + 1, x))
                        return true;

                    // right
                    if (x + 1 < n && !visited[grid[y,x + 1]] && grid[y,x + 1] <= t && Dfs(t, y, x + 1))
                        return true;

                    // up
                    if (y - 1 >= 0 && !visited[grid[y - 1,x]] && grid[y - 1,x] <= t && Dfs(t, y - 1, x))
                        return true;

                    // left
                    if (x - 1 >= 0 && !visited[grid[y,x - 1]] && grid[y,x - 1] <= t && Dfs(t, y, x - 1))
                        return true;

                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:

        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.

        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')

        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                return dfs(word1, word2, new Dictionary<string, int>());

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int dfs(string word1, string word2, Dictionary<string, int> memo)
        {
            if (word1 == word2) return 0; // if both eaqual returning zero
            if (word1 == "") return word2.Length; // if word1 is empty returning word2's length
            if (word2 == "") return word1.Length; // if word2 is empty returning word1's length

            string key = word1 + "#" + word2;
            if (memo.ContainsKey(key)) return memo[key];

            string s1 = (word1.Length > 1) ? word1.Substring(1) : "";
            string s2 = (word2.Length > 1) ? word2.Substring(1) : "";

            if (word1[0] == word2[0])
            {
                int operations = dfs(s1, s2, memo);
                memo.Add(key, operations);
            }
            else
            {
                int insert = 1 + dfs(word2[0] + word1, word2, memo);
                int delete = 1 + dfs(s1, word2, memo);
                int replace = 1 + dfs(s1, s2, memo);
                int operations = Math.Min(insert, Math.Min(delete, replace));
                memo.Add(key, operations);
            }
            return memo[key]; // returning the value 
        }
    }
}