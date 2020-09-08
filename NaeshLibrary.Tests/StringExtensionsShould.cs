#region File Info

// AUTHOR: Sean Hennessey
// DATE CREATED: 2020-09-08
//
// SOLUTION: FFArchiverCore
// PROJECT: NaeshLibrary.Tests
// FILE: StringExtensionsShould.cs

#endregion File Info

namespace NaeshLibrary.Tests
{
    using Extensions;
    using TestData;
    using Xunit;

    public class StringExtensionsShould
    {
        [Theory, StringExtensionsHashTestData]
        public void ReturnCorrectHashValue(string testVal, int expected)
        {
            int value = testVal.StringHash256();
            Assert.Equal(expected, value);
        }

        [Fact]
        public void ReturnFalseIfDoesNotContainInvalidPathCharacters()
        {
            var test = "this can be a valid path string.";
            bool isBadPathString = test.IsInvalidPath();
            Assert.False(isBadPathString);
        }

        [Theory, StringExtensionArrayTestData]
        public void ReturnTrueIfAnyElementsAreNullOrEmptyOrWhitespace(string[] testArray, bool expected)
        {
            bool val = testArray.IsAnyNullOrWhitespace();
            Assert.Equal(expected, val);
        }

        [Fact]
        public void ReturnTrueIfContainsInvalidPathCharacters()
        {
            var test = "<this is a bad path* string?>";
            bool isBadPathString = test.IsInvalidPath();
            Assert.True(isBadPathString);
        }
    }
}