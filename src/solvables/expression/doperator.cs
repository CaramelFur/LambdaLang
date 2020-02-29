using Sprache;
using System.Linq;
using LambdaLang.Scopes;

namespace LambdaLang.Solvables
{
  public class DOperator : Solvable
  {
    private char op;
    private Solvable A;
    private Solvable B;

    public DOperator(char op, Solvable A, Solvable B)
    {
      this.op = op;
      this.A = A;
      this.B = B;
    }

    public override Result Solve(Scope scope)
    {
      var ASolved = A.Solve(scope).Get();
      var BSolved = B.Solve(scope).Get();

      switch (op)
      {
        case '+':
          return new ConstantResult(ASolved + BSolved);
        case '-':
          return new ConstantResult(ASolved - BSolved);
        case '*':
          return new ConstantResult(ASolved * BSolved);
        case '/':
          return new ConstantResult(ASolved / BSolved);
        case '^':
          return new ConstantResult(ASolved ^ BSolved);
        case '%':
          return new ConstantResult(ASolved % BSolved);
        default:
          throw new LambdaException("Unkown operator: " + op);
      }
    }

    public override string ToString()
    {
      return "op(" + A + " " + op + " " + B + ")";
    }

    public static DOperator create(char op, Solvable A, Solvable B)
    {
      return new DOperator(op, A, B);
    }
  }
}