using Sprache;
using LambdaLang.Solvables;
using System.Linq;
using System;

namespace LambdaLang.LambdaParser
{
  public class ExpressionParser
  {
    static readonly Parser<char> Add = Generic.Operator('+');
    static readonly Parser<char> Subtract = Generic.Operator('-');
    static readonly Parser<char> Multiply = Generic.Operator('*');
    static readonly Parser<char> Divide = Generic.Operator('/');
    static readonly Parser<char> Modulo = Generic.Operator('%');
    static readonly Parser<char> Power = Generic.Operator('^');

    static readonly Parser<string> Arrow = Generic.Operator("->");

    static readonly Parser<Solvable> Constant =
         Parse.Decimal
         .Select(x => new Number(decimal.Parse(x)))
         .Named("number");

    static readonly Parser<Solvable> Variable =
      Generic.Word
      .Select(x => new Variable(x))
      .Named("Variable");

    static readonly Parser<Solvable> Function =
      from argument in Generic.Word
      from dot in Arrow
      from expr in Main
      select new Abstraction(argument, expr);

    static readonly Parser<Solvable> Factor =
        (from lparen in Parse.Char('(')
         from expr in Parse.Ref(() => Main)
         from rparen in Parse.Char(')')
         select expr).Named("expression")
         .Or(Constant)
         .Or(Function)
         .Or(Variable);
    //.Or(FCall);


    static readonly Parser<Solvable> Operand =
        (from sign in Parse.Char('-')
         from factor in Factor
         select new UOperator('-', factor)
         ).XOr(Factor).Token();



    static readonly Parser<Solvable> InnerTerm = Parse.ChainOperator(Power, Operand, DOperator.create);

    static readonly Parser<Solvable> Term = Parse.ChainOperator(Multiply.Or(Divide).Or(Modulo), InnerTerm, DOperator.create);

    static readonly Parser<Solvable> Expr = Parse.ChainOperator(Add.Or(Subtract), Term, DOperator.create);

    public static readonly Parser<Solvable> Main = Parse.ChainOperator(Parse.WhiteSpace.Optional(), Expr, COperator.create);

    public static void Test()
    {
      string testing = "a . a";

      var parsed = Main.Parse(testing);
      Console.WriteLine(parsed);
    }
  }
}