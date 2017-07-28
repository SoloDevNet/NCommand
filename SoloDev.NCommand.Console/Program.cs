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


            int i = 0;
            string[] output = new string[4];

            _marshal.Config.Output = (line) =>
            {
                output[i] = line.ToString();
                i++;
            };

            _marshal.ExecuteCommandString("test test-cmd --arg1 Arg1 --arg2 Arg2 --exec1 Exec1 --exec2 Exec2");
        }
    }
}
