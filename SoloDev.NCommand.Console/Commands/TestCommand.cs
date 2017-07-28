using SoloDev.NCommand.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoloDev.NCommand.Commands.Definition;

namespace SoloDev.NCommand.Console.Commands
{
    public class TestCommand : Command
    {
        public override string Name => "test-cmd";

        public override string Description => "test command";

        public override List<CommandParameter> ParametersDefinition => new List<CommandParameter>
        {
            new CommandParameter{ Name = "arg1", Type = ParameterType.Required },
            new CommandParameter{ Name = "arg2", Type = ParameterType.Optional },
        };

        public override void Run()
        {
            foreach(var param in Parameters)
            {
                Config.Output.Invoke($"{param.Key} : {param.Value}");
            }
        }
    }
}
