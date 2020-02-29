using Sprache;
using System.Linq;
using LambdaLang.Scopes;

namespace LambdaLang.Solvables
{
  public class UOperator : Solvable
  {
    private char op;
    private Solvable A;

    public UOperator(char op, Solvable A)
    {
      this.op = op;
      this.A = A;
    }

    public override Result Solve(Scope scope)
    {
      var ASolved = A.Solve(scope);
      if (op == '-')
      {
        return new ConstantResult(ASolved.Get() * -1);
      }
      else
      {
        throw new LambdaException("Unknown unary operator: " + op);
      }

    }

    public override string ToString()
    {
      return "uop(" + A + " " + op + ")";
    }
  }
}