using BaseTemplate.Server4.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace BaseTemplate.Server4
{
    class Program : ProgramBase
    {
        static void Main(string[] args)
        {
            SetConsoleCtrlHandler(Handler, true);
            service = new MainService();
            var host = HostFactory.New(x =>
            {
                x.Service<IMainService>(s =>
                {
                    s.ConstructUsing(name => service);
                    s.WhenStarted(tc => tc.Start(args));
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                //x.SetDescription("Server.HG.Master");
                //x.SetDisplayName("Server.HG.Master");
                //x.SetServiceName("Server.HG.Master");
            });

            host.Run();
        }
    }
}
