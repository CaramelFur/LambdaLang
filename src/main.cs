using System;
using System.IO;
using Sprache;
using LambdaLang.LambdaParser;

namespace LambdaLang
{
  class Program
  {
    static void Main(string[] args)
    {
      if (args.Length == 0)
      {
        throw new LambdaException("Please pass a file");
      }

      var test = File.ReadAllText(args[0]);
      var output = ProgramTreeParser.program.Parse(test);

      //Console.WriteLine(output);

      var result = output.RunMainWithArgs(decimal.Parse(args.Length > 1 ? args[1] : "0"));

      Console.WriteLine(result.Get());


    }
  }
}
