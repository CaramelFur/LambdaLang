using LambdaLang.Scopes;

namespace LambdaLang.Solvables
{
  public class Solvable {
    public virtual Result Solve(Scope scope){
      throw new LambdaException("You should not run a blank solvable: " + this.GetType());
    }
  }
}