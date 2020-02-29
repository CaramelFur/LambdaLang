using LambdaLang.Operations;
using LambdaLang.Scopes;
using LambdaLang.Solvables;
using System;

namespace LambdaLang
{
  public class ProgramTree
  {
    Operation[] operations;

    public ProgramTree(Operation[] operations)
    {
      this.operations = operations;
    }

    public FunctionResult GetMainFunction()
    {
      var scope = new Scope();

      for (var i = 0; i < operations.Length; i++)
      {
        operations[i].Run(scope);
      }

      Result main = scope.Retrieve("main");
      //var solved = ((FunctionResult) main).Apply();

      if (main.GetType() == typeof(FunctionResult))
      {
        return (FunctionResult)main;
      }
      else
      {
        throw new LambdaException("Main not is not a function");
      }
    }

    public Result RunMainWithArgs(dynamic argument){
      FunctionResult main = GetMainFunction();
      return main.Apply(new ConstantResult(argument));
    }

    public override string ToString()
    {
      var collector = "Program(\n";

      for (var i = 0; i < operations.Length; i++)
      {
        collector += operations[i] + "\n";
      }

      collector += ")";

      return collector;
    }
  }
}