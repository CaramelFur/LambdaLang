using LambdaLang.Solvables;
using LambdaLang.Scopes;
using System;

namespace LambdaLang.Solvables
{
  public class Abstraction : Solvable
  {
    readonly string argumentName;
    readonly Solvable expression;

    public Abstraction(string argument, Solvable expression)
    {
      this.argumentName = argument;
      this.expression = expression;
    }

    public override Result Solve(Scope scope)
    {
      return new FunctionResult(this, scope);
    }

    public Result Apply(Scope scope, Result argument)
    {
      var subScope = scope.GetChild();
      subScope.Store(argumentName, argument);

      return expression.Solve(subScope);
    }

    public override string ToString()
    {
      return "λ(" + argumentName + ") -> (" + expression + ")";
    }

    public static Abstraction create(dynamic any, string argument, Solvable expr)
    {
      return new Abstraction(argument, expr);
    }
  }
}