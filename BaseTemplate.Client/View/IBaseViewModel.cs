using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTemplate.Client.View
{
    public interface IBaseViewModel
    {
        void Events();
        void Subscribe();
        void Messages();
        void Commands();
    }
}
