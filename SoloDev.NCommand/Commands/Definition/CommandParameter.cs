using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloDev.NCommand.Commands.Definition
{
    public class CommandParameter
    {
        public CommandParameter()
        {
            Type = ParameterType.Required;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public ParameterType Type { get; set; }
    }
}