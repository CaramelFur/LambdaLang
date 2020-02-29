using System.Collections.Generic;
using LambdaLang.Solvables;

namespace LambdaLang.Scopes
{
  public class Scope
  {
    readonly Scope parent;
    readonly int depth;

    readonly Dictionary<string, Result> values = new Dictionary<string, Result>();

    public Scope()
    {
      depth = 0;
    }

    public Scope(Scope parent)
    {
      this.parent = parent;
      depth = this.parent.depth + 1;
    }

    public void Store(string name, Result solvable)
    {
      if (values.ContainsKey(name))
      {
        throw new LambdaException("Variable " + name + " already assigned");
      }

      values.Add(name, solvable);
    }

    public Result Retrieve(string name)
    {
      if (!values.ContainsKey(name))
      {
        if (depth == 0) throw new LambdaException("Variable " + name + " was never assigned");
        return parent.Retrieve(name);
      }

      return values[name];
    }

    public Scope GetChild()
    {
      return new Scope(this);
    }

    public override string ToString()
    {
      return "scope[" + depth + "]";
    }
  }
}