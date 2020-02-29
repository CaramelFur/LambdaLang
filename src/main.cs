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
      if(args.Length == 0){
        throw new LambdaException("Please pass a file");
      }

      var test = File.ReadAllText(args[0]);
      var output = ProgramTreeParser.program.Parse(test);

      output.Run();

    
    }
  }
}
