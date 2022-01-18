using Akka.Actor;
using Akka.Event;
using Akka.Logger.Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTemplate.Server5.Actor
{
    public class SeriLoggerActor : ReceiveActor
    {
        protected ILoggingAdapter logger = Context.GetLogger<SerilogLoggingAdapter>();
    }
}
