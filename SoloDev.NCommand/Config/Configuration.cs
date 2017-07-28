using System;
using System.Collections.Generic;
using System.Text;

namespace SoloDev.NCommand.Config
{
    public class Configuration
    {
        public Action<object> Output { get; set; }
        public Func<Type, object> ServiceProvider { get; set; }
        public Dictionary<string, Type> Commands { get; set; }
        public Dictionary<string, Type> Executors { get; set; }

        internal Actuator Actuator { get; set; }
        internal CommandMarshal Marshal { get; set; }

        public Configuration()
        {
            Output = Console.WriteLine;
            ServiceProvider = (type) => Activator.CreateInstance(type);
            Commands = new Dictionary<string, Type>();
            Executors = new Dictionary<string, Type>();

            Actuator = new Actuator(this);
        }
    }
}
