using System.Text;
using System.Text.RegularExpressions;

namespace ParserHelper {
    public static class ParserHelper 
    {
        public static string Parse(string input)
        {
            StringBuilder output = new();
            var parseResults = ParseOutWords(input);
            var words = parseResults.words;
            var separators = parseResults.separators;

            // Loop through each word and then append the first/last letters along with the separator characters.
            for(int x = 0; x < words.Count; x++)
            {
                var lastChar = words[x][^1];
                var firstChar = words[x][0];
                int between = words[x].Length - 2;
                // Print just the letter by itself if only one letter
                if(words[x].Length == 1)
                {
                    output.Append($"{firstChar} ");
                }
                // As long as there's a separator at the end, print it.
                else if(x < separators.Count)
                {
                    output.Append($"{firstChar}{between}{lastChar}{separators[x]}");
                }
                // This is the case when there's no separator at the end (which is the last word)
                else 
                {
                    output.Append($"{firstChar}{between}{lastChar}");
                }
            }
            return $"{output}";
        }

        #region Private Methods
        private static (List<string> words, List<string> separators) ParseOutWords(string strToCheck) 
        {
            List<string> words = [];
            List<string> separators = [];
            StringBuilder word = new();
            foreach(char l in strToCheck)
            {
                if(!IsAlphaNumeric($"{l}"))
                {
                    words.Add($"{word}");
                    separators.Add($"{l}");
                    word.Clear();
                }
                else 
                {
                    word.Append(l);
                }
            }
            // Add the word after the last separator.
            if(word.Length > 0)
            {
                words.Add($"{word}");
            }
            return (words, separators);
        }

        private static bool IsAlphaNumeric(string str)  
        {
            return str.All(c=> char.IsLetterOrDigit(c));
        }
        #endregion
    }
}