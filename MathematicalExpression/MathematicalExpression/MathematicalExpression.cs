namespace MathematicalExpression;

public class MathematicalExpression
{
    public static string subExpression;
    public double Solution(string expression)
    {
        var tempValues = expression.ToCharArray().ToList();

        tempValues.RemoveAll(x => x == ' ');

        List<string> values = SplitValues(tempValues);
        SplitExpression(values, 0);
        string evaluatedResult = EvaluateExpression(values);
        
        return Convert.ToDouble(evaluatedResult);
    }
    private static List<string> SplitValues(List<char> chars)
    {
        List<string> values = new List<string>();
        foreach(char c in chars)
        {
            values.Add(c.ToString());
        }
        return values;
    }
    private static void SplitExpression(List<string> values, int i)
    {
        subExpression = "";
        while (i < values.Count)
        {
            if (values[i].Equals("("))
            {
                int j = i + 1;
                while(j < values.Count)
                {
                    if (values[j].Equals("("))
                    {
                        SplitExpression(values, j);
                    }
                    else if (values[j].Equals(")"))
                    {
                        values[i] = EvaluateExpression(SplitValues(subExpression.ToCharArray().ToList()));
                        values.RemoveAt(j);
                        break;
                    }
                    subExpression += values[j];
                    values.RemoveAt(j);
                }
                subExpression = "";
            }
            i++;
        }
    }
    
    private static string EvaluateExpression(List<string> expression)
    {
        while(expression.Count != 1)
        {
            if (expression.Contains("/"))
            {
                int index = expression.FindIndex(x => x == "/");
                expression[index - 1] = (Convert.ToDouble(expression[index - 1]) / Convert.ToDouble(expression[index + 1])).ToString();
                expression.RemoveAt(index);
                expression.RemoveAt(index);
            }
            else if (expression.Contains("*"))
            {
                int index = expression.FindIndex(x => x == "*");
                expression[index - 1] = (Convert.ToDouble(expression[index - 1]) * Convert.ToDouble(expression[index + 1])).ToString();
                expression.RemoveAt(index);
                expression.RemoveAt(index);
            }
            else if (expression.Contains("+"))
            {
                int index = expression.FindIndex(x => x == "+");
                expression[index - 1] = (Convert.ToDouble(expression[index - 1]) + Convert.ToDouble(expression[index + 1])).ToString();
                expression.RemoveAt(index);
                expression.RemoveAt(index);
            }
            else if (expression.Contains("-"))
            {
                int index = expression.FindIndex(x => x == "-");
                expression[index - 1] = (Convert.ToDouble(expression[index - 1]) - Convert.ToDouble(expression[index + 1])).ToString();
                expression.RemoveAt(index);
                expression.RemoveAt(index);
            }
        }

        return expression[0]; 
    }
}
