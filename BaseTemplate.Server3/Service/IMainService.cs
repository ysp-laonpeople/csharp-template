using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTemplate.Server3.Service
{
    public interface IMainService
    {
        bool Start(string[] args);
        bool Stop();
    }
}
