using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaseTemplate.Server5.Service
{
    public class MainServiceBase
    {
        [DllImport("kernel32.dll")]
        protected static extern IntPtr GetConsoleWindow();
        protected readonly string configFile = "config.json";
        protected CancellationTokenSource cts = new CancellationTokenSource();
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
        protected T ReadConfig<T>(string configFile)
        {
            T config = (T)Activator.CreateInstance(typeof(T));
            if (!File.Exists(configFile))
            {
                string output = JsonConvert.SerializeObject(config);
                File.WriteAllText(configFile, output);
            }
            var input = File.ReadAllText(configFile);
            config = JsonConvert.DeserializeObject<T>(input);
            return config;
        }
        protected void Run()
        {
            //Console Command
            if (GetConsoleWindow() != IntPtr.Zero)
            {
                this.logger.Information($"Console Mode...");
                Task.Run(() => { 
                    if(consoleCommand != null) 
                        consoleCommand(); 
                }, cts.Token);
            }
            else
            {
                this.logger.Information($"Service Mode...");
            }
        }
    }
}
