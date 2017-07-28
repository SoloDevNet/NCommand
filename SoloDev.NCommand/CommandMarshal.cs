using SoloDev.NCommand.Commands;
using SoloDev.NCommand.Config;
using SoloDev.NCommand.Executors;
using SoloDev.NCommand.Executors.Impl;
using SoloDev.NCommand.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SoloDev.NCommand
{
    public class CommandMarshal
    {
        public Configuration Config { get; set; }
        
        public CommandMarshal(Configuration _config)
        {
            Config = _config;
            Config.Marshal = this;

            RegisterExecutorAssembly(typeof(Executor).GetTypeInfo().Assembly);
        }

        public void RegisterExecutorAssembly(Assembly assembly)
        {
            foreach (var type in assembly.ExportedTypes.Where(x => x.GetTypeInfo().IsSubclassOf(typeof(Executor))))
            {
                RegisterExecutor(type);
            }
        }

        public void RegisterExecutor(Type type)
        {
            Register(Config.Executors, type, typeof(Executor));
        }

        public void RegisterCommandAssembly(Assembly assembly)
        {
            foreach (var type in assembly.ExportedTypes.Where(x => x.GetTypeInfo().IsSubclassOf(typeof(Command))))
            {
                RegisterCommand(type);
            }
        }

        public void RegisterCommand(Type type)
        {
            Register(Config.Commands, type, typeof(Command));
        }

        private void Register(Dictionary<string, Type> haystack, Type toAdd, Type expectedType)
        {
            var isCorrectType = toAdd.GetTypeInfo().IsSubclassOf(expectedType);

            if (!isCorrectType)
            {
                throw new InvalidCastException($"Expected type {expectedType}");
            }

            var instance = Activator.CreateInstance(toAdd) as dynamic;
            haystack.Add(instance.Name, toAdd);
        }

        public void ExecuteCommandString(string wholeLine)
        {
            try
            {
                var executorName = wholeLine.GetExecutorName();
                var executor = Config.Actuator.CreateExecutorInstance(executorName, wholeLine);
                executor.Execute(wholeLine);
            }
            catch (Exception ex)
            {
                Config.Output.Invoke(ex);
            }
        }
    }
}
