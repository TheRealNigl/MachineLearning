using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EncogCSharp.Models;

namespace EncogCSharp
{
    class Program
    {
        private readonly List<ExampleInfo> examples = new List<ExampleInfo>();

        public Program()
        {
            const string method = "get_Info";
            var exampleTypes = Assembly
                    .GetExecutingAssembly()
                    .GetTypes().ToList()
                    .Where(t => t.Namespace != null && t.Namespace.StartsWith("Encog.Examples")).ToList();

            exampleTypes
                .ForEach(e =>
                {
                    if (e.GetMembers().Any(m => m.Name == method))
                    {
                        var info = e.InvokeMember(method, BindingFlags.Default | BindingFlags.InvokeMethod, null, null, new object[] { });
                        examples.Add((ExampleInfo)info);
                    }
                });
        }

        public void ListCommands()
        {
            var commands = new List<string>();

            Console.WriteLine(@"The following commands are available:");


            foreach (ExampleInfo info in examples)
            {
                commands.Add(info.Command.PadRight(20) + ": " + info.Title);
            }

            commands.Sort();

            foreach (String str in commands)
            {
                Console.WriteLine(str);
            }
        }

        public void Execute(String[] args)
        {
            int index = 0;
            bool pause = false;
            bool success = false;

            // process any options

            while (index < args.Length && args[index][0] == '-')
            {
                String option = args[index].Substring(1).ToLower();
                if ("pause".Equals(option))
                    pause = true;
                index++;
            }

            if (index >= args.Length)
            {
                Console.WriteLine(@"Must specify the example to run as the first argument");
                ListCommands();
                if (pause)
                {
                    Pause();
                }
                return;
            }

            String command = args[index++];

            // get any arguments
            var pargs = new String[args.Length - index];
            for (int i = 0; i < pargs.Length; i++)
            {
                pargs[i] = args[index + i];
            }

            foreach (ExampleInfo info in examples)
            {
                if (String.Compare(command, info.Command, true) == 0)
                {
                    IExample example = info.CreateInstance();
                    example.Execute(new ConsoleInterface(pargs));
                    success = true;
                    break;
                }
            }

            if (!success)
            {
                Console.WriteLine("Unknown command: " + command);
                ListCommands();
            }

            if (pause)
            {
                Pause();
            }
        }

        public void Pause()
        {
            Console.Write("\n\nPress any key to continue...");
            Console.ReadKey();
        }

        [STAThread]
        public static void Main(string[] args)
        {
            var app = new Program();
            app.Execute(args);

            Console.ReadLine();

            Console.WriteLine("-----------------------" + "Encog ML Introduction " + "---------------");
            EncogMLIntroduction encog = new EncogMLIntroduction();
            encog.Run();
            Console.WriteLine("----------------------------------------------------------------------\n");
            Console.WriteLine("Testing The four other function:");
            TestEncogAnalyst test = new TestEncogAnalyst();
            //test.TestIrisClassificationFF();
            Console.WriteLine("---------------------------------");
            Console.ReadLine();
        }
    }
}
