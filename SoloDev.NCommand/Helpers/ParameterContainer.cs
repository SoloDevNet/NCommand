using SoloDev.NCommand.Commands.Definition;
using SoloDev.NCommand.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoloDev.NCommand.Helpers
{
    public abstract class ParameterContainer
    {
        public abstract List<CommandParameter> ParametersDefinition { get; }

        public Dictionary<string, string> Parameters { get; set; }

        public ParameterContainer()
        {
            Parameters = new Dictionary<string, string>();
        }

        protected string GetParameter(string name, object defaultValue = null)
        {
            return Parameters.ContainsKey(name) ? Parameters[name] : defaultValue.ToString();
        }

        internal void SetParametersByLine(string wholeLine)
        {
            var @params = wholeLine.GetCommandParameters();

            foreach(var param in ParametersDefinition)
            {
                if (@params.ContainsKey(param.Name))
                {
                    Parameters[param.Name] = @params[param.Name];
                }
            }
        }

        internal IEnumerable<string> UndefinedRequiredParameters()
        {
            return ParametersDefinition
                .Where(x => !Parameters.Any(y => y.Key == x.Name) && x.Type == ParameterType.Required)
                .Select(x => x.Name);
        }

        internal bool HasUndefinedRequiredParameters => UndefinedRequiredParameters().Any();
    }
}
