using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoloDev.NCommand.Commands.Definition;

namespace SoloDev.NCommand.Executors.Impl
{
    public class ClsExecutor : Executor
    {
        public override string Description => "Clears the command line";

        public override string Name => "cls";

        public override List<CommandParameter> ParametersDefinition => new List<CommandParameter>();

        public override void Execute(string line)
        {
            if (Config.Output == System.Console.WriteLine)
            {
                System.Console.Clear();
            }
        }
    }
}
