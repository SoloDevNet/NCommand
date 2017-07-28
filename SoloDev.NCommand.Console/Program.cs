using SoloDev.NCommand.Console.Executors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloDev.NCommand.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var _marshal = new CommandMarshal(new Config.Configuration());

            _marshal.RegisterExecutorAssembly(typeof(TestExecutor).Assembly);
            _marshal.RegisterCommandAssembly(typeof(TestExecutor).Assembly);

            while (true)
            {
                _marshal.ExecuteCommandString(System.Console.ReadLine());
            }
        }
    }
}
