using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BaseTemplate.Server3.Config
{
    [Serializable]
    public class TestConfig
    {
        [DataMember]
        public string MachineID { get; set; }
        [DataMember]
        public string Host { get; set; }
        [DataMember]
        public int Port { get; set; }
        [DataMember]
        public string LogFilePath { get; set; }

        public TestConfig()
        {
            this.MachineID = "TestServer";
            this.Host = "127.0.0.1";
            this.Port = 7000;
            this.LogFilePath = $"./log/{this.MachineID}-.log";            
        }
    }
}
