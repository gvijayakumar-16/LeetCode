using NUnit.Framework;

namespace LeetCode.Test
{
    public class StringProblemTests
    {
        private StringProblem _stringProblem;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _stringProblem = new StringProblem();
        }

        [Test]
        public void ShouldReturnInteger()
        {
            var returnValue = _stringProblem.GetLongestSubstringWithoutRepeatingCharacters("somestring");
            Assert.AreEqual(typeof(int), returnValue.GetType());
        }

        [TestCase("bbbbb", 1)]
        [TestCase("abcabcbb", 3)]
        [TestCase("pwwkew", 3)]
        [TestCase(" ", 1)]
        [TestCase("au", 2)]
        public void ShouldReturnTheLongestSubstringWithoutRepeatingCharacters(string testValue, int expectedValue)
        {
            var returnValue = _stringProblem.GetLongestSubstringWithoutRepeatingCharacters(testValue);
            Assert.AreEqual(expectedValue, returnValue);
        }

        [TestCase("")]
        [TestCase(null)]
        public void ShouldReturnZeroForInvalidString(string value)
        {
            var returnValue = _stringProblem.GetLongestSubstringWithoutRepeatingCharacters(value);
            Assert.AreEqual(0, returnValue);
        }
    }
}