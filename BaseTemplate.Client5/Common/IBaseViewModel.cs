using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTemplate.Client5.Common
{
    public interface IBaseViewModel
    {
        void Commands();
        void Events();
        void Subscriptions();
        void Messages();
    }
}
