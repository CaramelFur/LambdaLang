using Sprache;
using LambdaLang.Operations;
using System.Linq;


namespace LambdaLang.LambdaParser
{
  public class ProgramTreeParser
  {
    public static readonly Parser<ProgramTree> program =
      from operations in OperationParser.operation.Many().End()
      select new ProgramTree(operations.ToArray());
  }
}