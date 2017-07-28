using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoloDev.NCommand.Commands.Definition;

namespace SoloDev.NCommand.Executors.Impl
{
    public class ExitExecutor : Executor
    {
        public override string Description => "Exits the application";

        public override string Name => "exit";

        public override List<CommandParameter> ParametersDefinition => new List<CommandParameter>();

        public override void Execute(string line)
        {
            Environment.Exit(0);
        }
    }
}
