using SoloDev.NCommand.Commands;
using SoloDev.NCommand.Executors;
using SoloDev.NCommand.Extensions;
using SoloDev.NCommand.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoloDev.NCommand.Config
{
    internal class Actuator
    {
        public Configuration Config { get; set; }

        public Actuator(Configuration _config)
        {
            Config = _config;
        }

        public Executor CreateExecutorInstance(string executorName, string wholeLine)
        {
            var executorType = Config.Executors[executorName];
            var instance = CreateInstance<Executor>(executorType, wholeLine);

            instance.Config = Config;

            return instance;
        }

        public Command CreateCommandInstance(string commandName, string wholeLine)
        {
            var commandType = Config.Commands[commandName];
            var instance = CreateInstance<Command>(commandType, wholeLine);

            instance.Config = Config;

            return instance;
        }

        private T CreateInstance<T>(Type type, string wholeLine) where T : ParameterContainer
        {
            var instance = Config.ServiceProvider.Invoke(type) as T;
            instance.SetParametersByLine(wholeLine);


            if (instance.HasUndefinedRequiredParameters)
            {
                var es = new List<Exception>();
                foreach(var urp in instance.UndefinedRequiredParameters())
                {
                    es.Add(new ArgumentNullException(urp));
                }

                throw new AggregateException(es);
            }

            return instance;
        }
    }
}
