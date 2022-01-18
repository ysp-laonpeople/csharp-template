using BaseTemplate.Server3.Config;
using BaseTemplate.Server3.Service;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace BaseTemplate.Server3
{

    public class MainService:MainServiceBase,IDisposable,IMainService
    {
        TestConfig config;
        
        public bool Start(string[] args)
        {
            
            this.config = ReadConfig<TestConfig>(configFile);

            InitLogger(this.config.LogFilePath);            
            consoleCommand = ConsoleCommand;
            base.Run();
            Task.Run(() =>
            {
                while (true)
                {                    
                    Console.WriteLine($"{ DateTime.Now.ToString()}");
                    Task.Delay(1000).Wait();
                }
            },cts.Token);
            this.logger.Information($"Started service:TestServer3");
            return true;
        }


        public bool Stop()
        {
            this.logger.Information($"Stop service:TestServer3");
            cts.Cancel();
            System.Threading.Thread.Sleep(3000);
            this.logger.Information($"Stoped service:TestServer3");
            return true;
        }
        public void Dispose()
        {
            
            cts.Cancel();
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
