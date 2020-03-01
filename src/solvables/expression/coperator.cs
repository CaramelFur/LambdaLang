using Sprache;
using System.Linq;
using LambdaLang.Scopes;

namespace LambdaLang.Solvables
{
  public class COperator : Solvable
  {
    public readonly Solvable func;
    public readonly Solvable? argument;

    public COperator(Solvable func)
    {
      this.func = func;
    }

    public COperator(Solvable func, Solvable A)
    {
      this.func = func;
      this.argument = A;
    }

    public override Result Solve(Scope scope)
    {
      var functionResult = func.Solve(scope);

      if (functionResult.GetType() != typeof(FunctionResult))
      {
        throw new LambdaException(func + " is not a function");
      }

      Result result;

      if (argument is Solvable)
      {
        var ASolved = argument.Solve(scope);
        result = ((FunctionResult)functionResult).Apply(ASolved);
      }
      else
      {
        result = ((FunctionResult)functionResult).Apply();
      }

      return result;
    }

    public override string ToString()
    {
      return func + " " + argument;
    }

    public static COperator create(dynamic any, Solvable func, Solvable arg)
    {
      return new COperator(func, arg);
    }
  }
}