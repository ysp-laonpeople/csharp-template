using Akka.Actor;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTemplate.Server
{
    public class LoaderActor : SeriLoggerActor, IDisposable
    {
        
        TestConfig config;
        Dictionary<string, IActorRef> chileActors = new Dictionary<string, IActorRef>();


        JsonSerializerSettings jsonSetting;
        string lastEndInspection = string.Empty;
        public LoaderActor(TestConfig postProcessorConfig)
        {
            this.config = postProcessorConfig;
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
            });
        }

        public void Dispose()
        {
 
        }
    }
}
