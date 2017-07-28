# NCommand

A library for clean command manipulation

Install the NuGet package using
```
PM> Install-Package SoloDev.NCommand
```

## Basic Usage

Create a .NET console application capable of running .NET Standard 1.5

```
public class Program
{
    public static void Main(string[] args)
    {
        var _marshal = new CommandMarshal(new Config.Configuration());

        _marshal.RegisterExecutorAssembly(typeof(TestExecutor).Assembly);
        _marshal.RegisterCommandAssembly(typeof(TestCommand).Assembly);

        while (true)
        {
            _marshal.ExecuteCommandString(System.Console.ReadLine());
        }
    }
}
```

Run the application and in the console type

```
help
```
