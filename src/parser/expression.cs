using Sprache;
using LambdaLang.Solvables;
using System.Linq;
using System;

namespace LambdaLang.LambdaParser
{
  public class ExpressionParser
  {
    static readonly Parser<string> Arrow = Generic.Operator("->");
    static readonly Parser<string> Triangle = Generic.Operator("|>");
    static readonly Parser<string> Exlcamation = Generic.Operator("!");

    static readonly Parser<Solvable> Constant =
         Parse.Decimal
         .Select(x => new Number(decimal.Parse(x)))
         .Named("number");

    static readonly Parser<Solvable> Variable =
      Generic.Word
      .Select(x => new Variable(x))
      .Named("Variable");

    static readonly Parser<Solvable> ArgFunction =
      from argument in Generic.Word
      from dot in Arrow
      from expr in Main
      select new Abstraction(argument, expr);

    static readonly Parser<Solvable> EmptFunction =
    from dot in Triangle
    from expr in Main
    select new Abstraction(expr);


    static readonly Parser<Solvable> Function = EmptFunction.Or(ArgFunction);

    static readonly Parser<Solvable> Factor =
        (from lparen in Parse.Char('(')
         from expr in Parse.Ref(() => Main)
         from rparen in Parse.Char(')')
         select expr).Named("expression")
         .Or(Constant)
         .Or(Function)
         .Or(Variable);

    static readonly Parser<Solvable> Exec =
      (
        from expr in Factor
        from excl in Exlcamation
        select new COperator(expr)
      ).Or(
        Factor
      );

    public static readonly Parser<Solvable> Main = Parse.ChainRightOperator(Parse.WhiteSpace.Optional(), Exec, COperator.create);

    public static void Test()
    {
      string testing = "a . a";

      var parsed = Main.Parse(testing);
      Console.WriteLine(parsed);
    }
  }
}