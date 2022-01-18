using Akka.Actor;
using BaseTemplate.Server5.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTemplate.Server5.Actor
{
    public class LoaderActor : SeriLoggerActor, IDisposable
    {
        
        TestConfig config;        
        JsonSerializerSettings jsonSetting;
        
        public LoaderActor(TestConfig Config)
        {
            this.config = Config;
            
            this.jsonSetting = new JsonSerializerSettings()
            {
                Error = delegate (object sender, ErrorEventArgs args)
                {
                    this.logger.Error(args.ErrorContext.Error.Message);
                    args.ErrorContext.Handled = true;
                }
            };            
            ReceiveAkkaMessageEvents();
        }


        private void ReceiveAkkaMessageEvents()
        {            
            Receive<string>(msg =>
            {
                Console.WriteLine($"{Sender}:{msg}");
                this.logger.Info($"{Sender}:{msg}");
            });
        }

        public void Dispose()
        {
 
        }
    }
}
