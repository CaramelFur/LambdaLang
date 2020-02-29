using Sprache;
using LambdaLang.Operations;

namespace LambdaLang.LambdaParser
{
  public class Generic
  {
    public static Parser<char> Operator(char op)
    {
      return Parse.Char(op).Token();
    }

    public static Parser<string> Operator(string op)
    {
      return Parse.String(op).Text().Token();
    }


    public static readonly Parser<string> Word = Parse
     .LetterOrDigit
     .XOr(Parse.Char('-'))
     .XOr(Parse.Char('_'))
     .AtLeastOnce()
     .Token()
     .Named("Word")
     .Text();
  }
}