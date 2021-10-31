using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTemplate.Client5.Message
{
    public class ChangedText
    {
        public string Value { get; private set; }
        public ChangedText(string value)
        {
            this.Value = value;
        }
    }
}
