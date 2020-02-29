using Sprache;
using System.Linq;
using LambdaLang.Scopes;

namespace LambdaLang.Solvables
{
  public class COperator : Solvable
  {
    private Solvable func;
    private Solvable A;

    public COperator(Solvable func, Solvable A)
    {
      this.func = func;
      this.A = A;
    }

    public override Result Solve(Scope scope)
    {
      var ASolved = A.Solve(scope);
      var functionResult = func.Solve(scope);

      if (functionResult.GetType() != typeof(FunctionResult))
      {
        throw new LambdaException(func + " is not a function");
      }

      var function = ((FunctionResult) functionResult).Apply(ASolved);
      return function;
    }

    public override string ToString()
    {
      return "call(" + func + " <- " + A + ")";
    }

    public static COperator create(dynamic any, Solvable func, Solvable arg)
    {
      return new COperator(func, arg);
    }
  }
}