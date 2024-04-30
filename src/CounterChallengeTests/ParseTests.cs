

namespace CounterChallengeTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void HappyPath1()
    {
        // Arrange
        string expectedAnswer = "I0t w1s m2y a1d m2y a y2r a1o";

        // Act
        string actualAnswer = ParserHelper.ParserHelper.Parse("It was many and many a year ago");

        // Assert
        Assert.AreEqual(expectedAnswer, actualAnswer, "The response doesn't match the expected output!");
    }

        [TestMethod]
    public void HappyPath2()
    {
        // Arrange
        string expectedAnswer = "C7t,M7t:C9n";

        // Act
        string actualAnswer = ParserHelper.ParserHelper.Parse("Copyright,Microsoft:Corporation");

        // Assert
        Assert.AreEqual(expectedAnswer, actualAnswer, "The response doesn't match the expected output!");
    }

    [TestMethod]
    public void UnhappyPath_Error()
    {
        // Arrange
        string expectedAnswer = "this,is,wrong and will error out";

        // Act
        string actualAnswer = ParserHelper.ParserHelper.Parse("Copyright,Microsoft:Corporation");

        // Assert
        
        Assert.AreNotEqual(expectedAnswer, actualAnswer, "The response doesn't match the expected output!");
    }
}