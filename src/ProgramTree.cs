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

    public void Run()
    {
      var scope = new Scope();

      for (var i = 0; i < operations.Length; i++)
      {
        operations[i].Run(scope);
      }

      dynamic main = scope.Retrieve("main").Get();
      //var solved = ((FunctionResult) main).Apply();
      
      if (main.GetType() != typeof(FunctionResult))
      {
        Console.WriteLine(main);
      }
      else
      {
        throw new LambdaException("Main not a result");
      }
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