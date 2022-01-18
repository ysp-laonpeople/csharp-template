using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace BaseTemplate.Server1
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new MainService();
            var host = HostFactory.New(x =>
            {
                x.Service<MainService>(s =>
                {
                    s.ConstructUsing(name => service);
                    s.WhenStarted(tc => tc.Start(args));
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.SetDescription("BaseTemplate.Server1");
                x.SetDisplayName("BaseTemplate.Server1");
                x.SetServiceName("BaseTemplate.Server1");
            });

            host.Run();
        }
    }
}
