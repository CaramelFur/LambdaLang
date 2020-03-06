# LambdaLang

Lambdalang is a small project trying to implement the lambda calculus in an easy to use programming language.

## Running

You can simply run the interpreter by executing `dotnet run` in the root directory.
You can also build the program with `dotnet build`.

It does not interpret code live so you will have to specify a file with code as only argument.

## Syntax

Every line of code is an assignment to a constant variable, so it will aways follow this syntax:
`${variablename} = ${expression};`

The language does not contain any mathmatical operators, so everything will be composed of functions and number constants.
It does however have parentheses.

A function is created with the `->` sign, every function can only take one argument. So it follows this syntax:
`${argumentName} -> ${expression}`

It is also possible to create a function that does not take any arguments by using the `|>` sign, so that follows:
`|> ${expression}`

You can call any function by simply following the function name with an expression, so like this:
`${functionName} ${expression}`

Functions are executed right to left, so if you have the code:
`test = functionA functionB 3;`
It will first evaluate it like this:
`test = (functionA (functionB (3)))`

Every program also requires a main function to be evaluated, this is created just like any other variable only this time the variable is main and must contain a function. So for example:
`main = |> 3;`

### Extra functions

The language also has two built in functions:

- `church`
- `unchurch`

These two functions create and solve church numerals, the church function takes a number and returns the corresponding church numeral.
The unchurch function takes a church numeral as argument and solves it back to a normal number.

## Example

This would be how you calculate 2 + 3:

```haskell
churchA = church 2;
churchB = church 3;

plus = m -> n -> f -> x -> m f (n f x);

churchResult = plus churchA churchB;

main = |> (unchurch churchResult);
```

There are also a couple of examples in the examples folder.
