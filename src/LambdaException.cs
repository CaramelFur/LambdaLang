using System;

namespace LambdaLang
{
  public class LambdaException : Exception
  {
    public LambdaException()
    : base() { }

    public LambdaException(string message)
        : base(message) { }

    public LambdaException(string format, params object[] args)
        : base(string.Format(format, args)) { }

    public LambdaException(string message, Exception innerException)
        : base(message, innerException) { }

    public LambdaException(string format, Exception innerException, params object[] args)
        : base(string.Format(format, args), innerException) { }
  }

}