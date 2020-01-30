using System.Collections.Generic;

namespace LeetCode
{
    public class StringProblem
    {
        public int GetLongestSubstringWithoutRepeatingCharacters(string value)
        {
            var longestSubstring = 0;
            if (string.IsNullOrEmpty(value)) return longestSubstring;
            var characters = value.ToCharArray();
            var nonRepeatingCharacters = new List<char> { characters[0] };
            longestSubstring = nonRepeatingCharacters.Count;
            for (var i = 1; i < characters.Length; i++)
            {
                if (!nonRepeatingCharacters.Contains(characters[i]))
                {
                    nonRepeatingCharacters.Add(characters[i]);
                    longestSubstring = nonRepeatingCharacters.Count;
                    continue;
                }
                longestSubstring = nonRepeatingCharacters.Count > longestSubstring ? nonRepeatingCharacters.Count : longestSubstring;
                nonRepeatingCharacters.Clear();
                nonRepeatingCharacters.Add(characters[i]);
            }
            return longestSubstring;
        }
    }
}
