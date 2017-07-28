using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoloDev.NCommand.Commands.Definition;

namespace SoloDev.NCommand.Executors.Impl
{
    public class RunExecutor : Executor
    {
        public override string Description =>
@"Runs a specific command

run <CommandName> [--<Param1Name> <Param1Value>, ...]";

        public override string Name => "run";

        public override List<CommandParameter> ParametersDefinition => new List<CommandParameter>();

        public override void Execute(string line)
        {
            var command = GetConsoleCommand(line);
            command.Run();
        }
    }
}
