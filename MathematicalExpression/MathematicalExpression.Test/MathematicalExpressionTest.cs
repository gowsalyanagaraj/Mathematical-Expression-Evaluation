namespace MathematicalExpression.Test;

[TestClass]
public class MathematicalExpressionTest
{
    [TestMethod]
    public void TestMethod1()
    {
        // Arrange
        MathematicalExpression solution = new MathematicalExpression();
        string expression = "3 + (2 * 4) - 5 / (1 + 1)";

        // Act
        double result = solution.Solution(expression);

        // Assert
        Assert.AreEqual(result, 8.5);
    }

    [TestMethod]
    public void TestMethod2()
    {
        // Arrange
        MathematicalExpression solution = new MathematicalExpression();
        string expression = "3 + (2 * 4) - 5 / ((6 / 6) + 1)";

        // Act
        double result = solution.Solution(expression);

        // Assert
        Assert.AreEqual(8.5, result);
    }
}
