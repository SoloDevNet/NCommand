using SoloDev.NCommand.Console.Core.Executors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloDev.NCommand.Console.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var _marshal = new CommandMarshal(new Config.Configuration());

            _marshal.RegisterExecutorAssembly(typeof(TestExecutor).Assembly);
            _marshal.RegisterCommandAssembly(typeof(TestExecutor).Assembly);

            _marshal.ExecuteCommandString("test test-cmd --arg1 Hello --arg2 world --exec1 Hey --exec2 you");
            System.Console.ReadLine();
        }
    }
}
