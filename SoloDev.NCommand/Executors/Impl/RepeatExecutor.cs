using SoloDev.NCommand.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SoloDev.NCommand.Commands.Definition;

namespace SoloDev.NCommand.Executors.Impl
{
    public class RepeatExecutor : Executor
    {
        public override string Description =>
@"Runs a specific command several times with a timeout

repeat <CommandName> [--<Param1Name> <Param1Value>, ...] --times <Value>, --timeout <MillisecondsValue>";

        public override string Name => "repeat";

        public override List<CommandParameter> ParametersDefinition => new List<CommandParameter>
        {
            new CommandParameter{ Name = "times", Type = ParameterType.Optional, Description = "times of execution" },
            new CommandParameter{ Name = "timeout", Type = ParameterType.Optional, Description = "timeout of next execution in milliseconds" },
        };

        public override async void Execute(string line)
        {
            var times = int.Parse(GetParameter("times", 1));
            var timeout = Math.Max(int.Parse(GetParameter("timeout", 0)), 0);

            for (int i = 0; i < times || times < 0; i++) 
            {
                await Task.Delay(timeout).ContinueWith((result) => {
                    Config.Marshal.ExecuteCommandString($"run {line.GetRest()}");
                });
            }
        }
    }
}
