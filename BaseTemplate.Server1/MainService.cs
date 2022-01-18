using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTemplate.Server1
{
    public class MainService
    {

        public bool Start(string[] args)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine($"{ DateTime.Now.ToString()}");
                    Task.Delay(1000).Wait();                    
                }
            });

            return true;
        }

        public bool Stop()
        {
            return true;
        }
    }
}
