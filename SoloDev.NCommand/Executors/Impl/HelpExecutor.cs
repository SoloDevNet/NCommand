using SoloDev.NCommand.Commands.Definition;
using SoloDev.NCommand.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloDev.NCommand.Executors.Impl
{
    public class HelpExecutor : Executor
    {
        public override string Name => "help";

        public override string Description => 
@"Display general or specific help for commands and executors

help [<CommandOrExecutorName>]";

        public override List<CommandParameter> ParametersDefinition => new List<CommandParameter>();

        public override void Execute(string line)
        {
            Config.Output.Invoke("");
            var commandOrExecutor = line.GetRest().GetFirst();

            if (!string.IsNullOrEmpty(commandOrExecutor))
            {
                try
                {
                    HelpForCommand(line);
                }
                catch
                {
                    HelpForExecutor(commandOrExecutor);
                }
            }
            else
            {
                GeneralHelp();
            }
            Config.Output.Invoke("");
        }

        private void GeneralHelp()
        {
            Config.Output.Invoke("List of executors:");
            foreach (var executor in Config.Executors)
            {
                Config.Output.Invoke(executor.Key);
            }
            Config.Output.Invoke("");
            Config.Output.Invoke("help <executor>, for more help for a specific executor");

            Config.Output.Invoke("");
            Config.Output.Invoke("");

            Config.Output.Invoke("List of commands:");
            foreach (var command in Config.Commands)
            {
                Config.Output.Invoke(command.Key);
            }
            Config.Output.Invoke("");
            Config.Output.Invoke("help <command>, for more help for a specific command");
        }

        private void HelpForCommand(string line)
        {
            var commandInstance = GetConsoleCommand(line);

            Config.Output.Invoke($"{commandInstance.Description}");

            Config.Output.Invoke("");
            Config.Output.Invoke("Example:");

            string commandExample = commandInstance.Name;

            foreach (var requiredParam in commandInstance.ParametersDefinition.Where(x => x.Type == ParameterType.Required))
            {
                commandExample += $" --{requiredParam.Name} <Value>";
            }

            foreach (var optionalParam in commandInstance.ParametersDefinition.Where(x => x.Type == ParameterType.Optional))
            {
                commandExample += $" --{optionalParam.Name} <Value>";
            }

            Config.Output.Invoke(commandExample);
            Config.Output.Invoke("");
            foreach (var requiredParam in commandInstance.ParametersDefinition.Where(x => x.Type == ParameterType.Required))
            {
                Config.Output.Invoke($"--{requiredParam.Name} is requred, {requiredParam.Description}");
            }

            foreach (var optionalParam in commandInstance.ParametersDefinition.Where(x => x.Type == ParameterType.Optional))
            {
                Config.Output.Invoke($"--{optionalParam.Name} is optional, { optionalParam.Description}");
            }
        }

        private void HelpForExecutor(string exectorName)
        {
            var executorInstance = Activator.CreateInstance(Config.Executors[exectorName.GetFirst()]) as Executor;

            Config.Output.Invoke($"{executorInstance.Description}");
        }
    }
}
