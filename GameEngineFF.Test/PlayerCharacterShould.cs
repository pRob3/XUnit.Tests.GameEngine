using System;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInexperiencedWhenNew()
        {
            PlayerCharacter sut = new();

            Assert.True(sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            PlayerCharacter sut = new()
            {
                FirstName = "John",
                LastName = "Smith"
            };

            Assert.Equal("John Smith", sut.FullName);
        }

        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            PlayerCharacter sut = new()
            {
                FirstName = "John",
                LastName = "Smith"
            };

            Assert.StartsWith("John", sut.FullName);
        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            PlayerCharacter sut = new()
            {
                FirstName = "John",
                LastName = "Smith"
            };

            Assert.EndsWith("Smith", sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
            PlayerCharacter sut = new()
            {
                FirstName = "JOHN",
                LastName = "SMITH"
            };

            Assert.EndsWith("Smith", sut.FullName, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {
            PlayerCharacter sut = new()
            {
                FirstName = "John",
                LastName = "Smith"
            };

            Assert.Contains("hn Sm", sut.FullName);
        }

        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            PlayerCharacter sut = new()
            {
                FirstName = "John",
                LastName = "Smith"
            };

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.FullName);
        }
    }
}
