using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BucketExtensions
{
    public static class StringExtensions {
        
        // checks if string contains a match for a regex string
        public static bool IsMatch(this string input, string regexString) {

            var rx = new Regex(regexString);
            return rx.IsMatch(input);
        }

        // returns an array of strings that match the inputted regex string
        public static string[] GetMatches(this string input, string regexString) {
            
            var rx = new Regex(regexString);
            var matchList = new List<string>();
            var matches = rx.Matches(input);
            foreach (var i in matches) {
                matchList.Add(i.ToString());
            }
            return matchList.ToArray();
        }

        // checks if strings are "similar" - is one string contained in the other?
        public static bool SimilarTo(this string i, string input, bool ignoreCase = false) {

            var inputText = i;
            
            if (ignoreCase) {
                
                inputText = inputText.ToUpper().Replace(" ", "");
                input = input.ToUpper().Replace(" ", "");
            } 
            else {
                
                inputText = inputText.Replace(" ", "");
                input = input.Replace(" ", "");
            }
            
            if (inputText.Contains(input) || input.Contains(inputText))
                return true;
            
            else
                return false;
        }

        // returns the longest word in the string
        public static string LongestWord(this string input)
        {
            var inputArray = input.Split(' ');
            string longestString = "";
            foreach (var i in inputArray) {

                if (i.Length > longestString.Length) 
                    longestString = i;
            }
            return longestString;
        }

        // Counts the number of words in the given string, returning them sorted by count, desc. Returns only words with a count greater than the minimum count
        public static Dictionary<string, int> WordCount(this string input, bool ignoreCase = false, int minCount = 0)
        {
            if (minCount < 0)
                throw new ArgumentException("Word Count: minimum word count cannot be less than 0");

            var wordDict = new Dictionary<string, int>();
            var inputText = input;

            if (ignoreCase) 
                inputText = inputText.ToLower();

            var inputArray = inputText.Split(' ');
            foreach (var i in inputArray) {
                
                if (wordDict.ContainsKey(i))
                    wordDict[i] += 1;
                else
                    wordDict[i] = 1;
            }
            var sortedDict = SortDict(wordDict);
            var returnDict = new Dictionary<string, int>();
            foreach (var i in sortedDict) {
                
                if (i.Value >= minCount)
                    returnDict[i.Key] = i.Value;
            }
            return returnDict;
        }

        // sorts <string, int> dictionary by value in desc order
        private static Dictionary<string, int> SortDict(Dictionary<string, int> inputDict)
        {
            var sortedList = inputDict.OrderByDescending(kp => kp.Value).ToList();
            var sortedDict = new Dictionary<string, int>();
            foreach (var i in sortedList) {

                sortedDict[i.Key] = i.Value;
            }   
            return sortedDict;      
        }

        // counts the number of characters in a string
        public static int CharacterCount(this string input, char inputChar, bool ignoreCase = false) {

            var inputText= input;
            var charCount = 0;

            if (ignoreCase) {
                
                inputChar = inputChar.ToString().Trim().ToUpper().ToCharArray()[0];
                inputText = inputText.ToUpper();
            } 

            foreach (var i in inputText) {
                
                if (i == inputChar)
                    charCount++;
            }

            return charCount;
        }

        public static string FillString(this string input, int finalLength, char fillCharacter)
        {
            int charsToAdd = (int)Math.Floor(((double)finalLength - (double)input.Length)/2);
            
            var returnString = input.PadLeft(input.Length + charsToAdd, fillCharacter);
            returnString = returnString.PadRight(returnString.Length + charsToAdd, fillCharacter);

            if (returnString.Length < finalLength) 
                returnString += fillCharacter.ToString();

            return returnString;
        }

        public static string ClassToString<T>(this T input)
        {
            var properties = typeof(T).GetProperties();

            var displayString = $"{typeof(T)}:";

            foreach (var i in properties)
            {
                displayString += $" {i.Name}: {i.GetValue(input)};";
            }

            return displayString;
        }

        public static int CalcLevDistance(this string source, string target, bool ignoreCase = false)
        {
            if (string.IsNullOrWhiteSpace(source) && string.IsNullOrWhiteSpace(target))
            {
                return 0;
            }

            if (string.IsNullOrEmpty(source))
            {
                return target.Length;
            }

            if (string.IsNullOrEmpty(target))
            {
                return source.Length;
            }

            if (ignoreCase)
            {
                source = source.ToLower();
                target = target.ToLower();
            }

            var sourceLength = source.Length;
            var targetLength = target.Length;

            if (sourceLength > targetLength)
            {
                Swap(ref target, ref source);
                Swap(ref sourceLength, ref targetLength);
            }

            var maxi = sourceLength;
            var maxj = targetLength;

            int[] dCurrent = new int[maxi + 1];
            int [] dMinus1 = new int[maxi + 1];
            int[] dMinus2 = new int[maxi + 1];
            int[] dSwap;

            for (int i = 0; i <= maxi; i++)
            {
                dCurrent[i] = i;
            }

            int jm1 = 0, im1 = 0, im2 = -1;

            for (int j = 1; j <= maxj; j++)
            {
                dSwap = dMinus2;
                dMinus2 = dMinus1;
                dMinus1 = dCurrent;
                dCurrent = dSwap;

                int minDistance = int.MaxValue;
                dCurrent[0] = j;
                im1 = 0;
                im2 = -1;

                for (int i = 1; i <= maxi; i++)
                {
                    int cost = source[im1] == source[jm1] ? 0 : 1;

                    int del = dCurrent[im1] + 1;
                    int ins = dMinus1[i] + 1;
                    int sub = dMinus1[im1] + cost;

                    int min = (del > ins) ? (ins > sub ? sub : ins) : (del > sub ? sub : del);

                    if (i > 1 && j > 1 && source[im2] == target[jm1] && source[im1] == target[j - 2])
                    {
                        min = Math.Min(min, dMinus2[im2] + cost);
                    }

                    dCurrent[i] = min;
                    if (min < minDistance)
                    {
                        minDistance = min;
                    }
                    im1++;
                    im2++;
                }

                jm1++;
            }

            var result = dCurrent[maxi];
            return result;

        }

        private static void Swap<T>(ref T arg1, ref T arg2)
        {
            T temp = arg1;
            arg1 = arg2;
            arg2 = temp;
        }
    }
}