namespace LambdaLang.Solvables
{
  public class ConstantResult : Result
  {
    readonly dynamic result;

    public ConstantResult(dynamic result)
    {
      this.result = result;
    }

    public override dynamic Get()
    {
      return result;
    }

    public override string ToString()
    {
      return "Crestult(" + result + ")";
    }
  }
}