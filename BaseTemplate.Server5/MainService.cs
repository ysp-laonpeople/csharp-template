using Akka.Actor;
using Akka.Routing;
using BaseTemplate.Server5.Actor;
using BaseTemplate.Server5.Config;
using BaseTemplate.Server5.Service;
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


namespace BaseTemplate.Server5
{

    public class MainService:MainServiceBase,IDisposable,IMainService
    {
        TestConfig config;
        ActorSystem actorSystem;
        public bool Start(string[] args)
        {
            this.config = ReadConfig<TestConfig>(configFile);

            InitLogger(this.config.LogFilePath);
            InitActor(this.config);
            consoleCommand = ConsoleCommand;
            base.Run();
            this.logger.Information($"Started service:TestServer");
            return true;
        }


        public bool Stop()
        {
            this.actorSystem.Dispose();
            cts.Cancel();
            System.Threading.Thread.Sleep(3000);
            this.logger.Information($"Stoped service:TestServer");
            return true;
        }
        public void Dispose()
        {
            this.actorSystem.Dispose();
            cts.Cancel();
        }

        void InitActor(TestConfig config)
        {
            this.actorSystem = ActorSystem.Create("TESETSERVER");

            ActorHelper.AddActor("LoaderActor", actorSystem.ActorOf(Props.Create<LoaderActor>(config)
                .WithDispatcher("akka.actor.pinned-dispatcher"), "LoaderActor"));
        }
        void ConsoleCommand()
        {

            while (true)
            {

                var data = string.Empty;

                data = Console.ReadLine();

                if (data == null || data.Length == 0)
                    continue;

                if (data.Substring(0, 1) == "i")
                {
                    var loader = ActorHelper.GetActor("LoaderActor");
                    loader.Tell("test text", loader);
                    //var sel = this.actorSystem.ActorSelection("akka.tcp://LauncherActor@localhost:9020/user/LoaderActor");
                    //sel.Tell("remotetest");

                }
                if (data.Substring(0, 1) == "e")
                {
                    this.Stop();
                    Environment.Exit(0);
                }
            };

        }

    }
}
