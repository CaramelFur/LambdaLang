using LambdaLang.Scopes;

namespace LambdaLang.Solvables
{
  public class FunctionResult : Result
  {
    readonly Abstraction result;
    readonly Scope scope;

    public FunctionResult(Abstraction result, Scope scope)
    {
      this.result = result;
      this.scope = scope;
    }

    public override dynamic Get()
    {
      return result;
    }

    public Result Apply()
    {
      return result.Apply(scope);
    }

    public Result Apply(Result argument)
    {
      return result.Apply(scope, argument);
    }

    public override string ToString()
    {
      return "Fresult(" + result + ", " + scope +")";
    }
  }
}