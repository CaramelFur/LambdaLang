using Sprache;
using LambdaLang.Operations;

namespace LambdaLang.LambdaParser
{
  public class OperationParser
  {
    static readonly CommentParser Comment = new CommentParser("#", "/#", "#/", "\n");

    static readonly Parser<char> Equuals = Generic.Operator('=');
    static readonly Parser<string> SemiColon = Generic.Operator(";");

    static readonly Parser<Operation> assignOperation =
      from variable in Generic.Word
      from equuals in Equuals
      from solvable in ExpressionParser.Main
      from end in SemiColon.Or<dynamic>(Parse.LineEnd)
      select new AssignOp(variable, solvable);

    public static readonly Parser<Operation> operation =
      from before in Comment.AnyComment.Many().Optional()
      from operation in assignOperation
      from after in Comment.AnyComment.Many().Optional()
      select operation;
  }
}