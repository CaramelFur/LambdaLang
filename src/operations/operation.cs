using LambdaLang.Solvables;

namespace LambdaLang.Operations
{
  public class Operation
  {
    public virtual void Run(Scopes.Scope scope)
    {
      throw new LambdaException("You should not run a blank operation");
    }
  }
}