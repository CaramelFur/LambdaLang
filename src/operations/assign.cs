using LambdaLang.Solvables;
using LambdaLang.Scopes;

namespace LambdaLang.Operations
{
  public class AssignOp : Operation
  {
    readonly string name;
    readonly Solvable solvable;

    public AssignOp(string name, Solvable solvable)
    {
      this.name = name;
      this.solvable = solvable;
    }
    
    public override void Run(Scope scope)
    {
      var solved = solvable.Solve(scope);
      scope.Store(name, solved);
    }

    public override string ToString()
    {
      return "AssignOp(" + name + " = " + solvable + ")";
    }
  }
}