namespace LambdaLang.Solvables
{
  public class Result
  {
    public virtual dynamic Get()
    {
      throw new LambdaException("You cannot get an empty result");
    }
  }
}