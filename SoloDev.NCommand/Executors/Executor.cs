using SoloDev.NCommand.Commands;
using SoloDev.NCommand.Commands.Definition;
using SoloDev.NCommand.Config;
using SoloDev.NCommand.Extensions;
using SoloDev.NCommand.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloDev.NCommand.Executors  
{
    public abstract class Executor : ParameterContainer
    {
        public Configuration Config { get; set; }
        
        public abstract string Name { get; }

        public abstract string Description { get; }

        public abstract void Execute(string wholeLine);
                
        protected virtual Command GetConsoleCommand(string wholeLine)
        {
            var commandName = wholeLine.GetCommandName();
            var commandInstance = Config.Actuator.CreateCommandInstance(commandName, wholeLine);

            return commandInstance;
        }
    }
}
