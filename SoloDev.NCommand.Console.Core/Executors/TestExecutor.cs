using SoloDev.NCommand.Executors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoloDev.NCommand.Commands.Definition;

namespace SoloDev.NCommand.Console.Core.Executors
{
    public class TestExecutor : Executor
    {
        public override string Name => "test";

        public override string Description => "desc";

        public override List<CommandParameter> ParametersDefinition => new List<CommandParameter>
        {
            new CommandParameter{ Name = "exec1", Type = ParameterType.Required },
            new CommandParameter{ Name = "exec2", Type = ParameterType.Optional }
        };

        public override void Execute(string wholeLine)
        {
            foreach (var param in Parameters)
            {
                Config.Output.Invoke($"{param.Key} : {param.Value}");
            }

            var command = GetConsoleCommand(wholeLine);

            command.Run();
        }
    }
}
