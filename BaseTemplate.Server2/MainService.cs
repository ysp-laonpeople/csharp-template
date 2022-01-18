using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace BaseTemplate.Server2
{

    public class MainService:IDisposable,IMainService
    {
        protected ILogger logger;
        protected Action consoleCommand;
        protected void InitLogger(string logFilePath)
        {
            this.logger = new LoggerConfiguration()
                .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
                .WriteTo.Console()
                .MinimumLevel.Verbose()
                .CreateLogger();

            Serilog.Log.Logger = logger;
        }

        public bool Start(string[] args)
        {
            InitLogger(@"./logs/log-.log");
            Task.Run(ConsoleCommand);
            Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine($"{ DateTime.Now.ToString()}");
                    Task.Delay(1000).Wait();
                }
            });
            this.logger.Information($"Started service:TestServer2");
            return true;
        }


        public bool Stop()
        {
            this.logger.Information($"Stoped service:TestServer2");
            return true;
        }
        public void Dispose()
        {
           
        }

        void ConsoleCommand()
        {

            while (true)
            {
                var data = string.Empty;

                data = Console.ReadLine();
                Console.WriteLine($"input: {data}");
                
            };
        }
    }
}
