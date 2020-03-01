using LambdaLang.Scopes;
using LambdaLang.Solvables;
using System;

namespace LambdaLang.Libraries
{
  class Church
  {
    public static void AddToScope(Scope scope)
    {
      scope.Store("church", new ChurchCreateAbstraction().Solve(scope));
      scope.Store("unchurch", new ChurchRemoveAbstraction().Solve(scope));
    }
  }

  class ChurchCreateAbstraction : Abstraction
  {
    public ChurchCreateAbstraction() : base(new Solvable()) { }

    public override Result Apply(Scope scope, Result argument)
    {
      int number = int.Parse(argument.Get().ToString());

      Solvable expresion = new Variable("x");

      for (int i = 0; i < number; i++)
      {
        expresion = new COperator(new Variable("f"), expresion);
      }

      expresion = new Abstraction("x", expresion);
      expresion = new Abstraction("f", expresion);

      return expresion.Solve(scope);
    }

    public override Result Apply(Scope scope)
    {
      return Apply(scope, new Result());
    }

    public override string ToString()
    {
      return "λ-church";
    }
  }

  class ChurchRemoveAbstraction : Abstraction
  {

    private static Abstraction helperAbstraction = new ChurchHelperAbstraction();

    public ChurchRemoveAbstraction() : base(new Solvable()) { }

    public override Result Apply(Scope scope, Result argument)
    {
      if (argument.GetType() != typeof(FunctionResult))
      {
        return new ConstantResult(0);
      }

      Result helperResult = helperAbstraction.Solve(scope);

      Result xFunc = ((FunctionResult)argument).Apply(helperResult);

      if (xFunc.GetType() != typeof(FunctionResult))
      {
        return new ConstantResult(0);
      }

      Result solved = ((FunctionResult)xFunc).Apply(new ConstantResult(0));

      return solved;
    }

    public override Result Apply(Scope scope)
    {
      return Apply(scope, new Result());
    }

    public override string ToString()
    {
      return "λ-unchurch";
    }
  }

  class ChurchHelperAbstraction : Abstraction
  {
    public ChurchHelperAbstraction() : base(new Solvable()) { }

    public override Result Solve(Scope scope)
    {
      return new FunctionResult(this, scope);
    }

    public override Result Apply(Scope scope, Result argument)
    {
      int number = int.Parse(argument.Get().ToString());

      return new ConstantResult(number + 1);
    }

    public override Result Apply(Scope scope)
    {
      return Apply(scope, new Result());
    }

    public override string ToString()
    {
      return "λ-church";
    }
  }
}