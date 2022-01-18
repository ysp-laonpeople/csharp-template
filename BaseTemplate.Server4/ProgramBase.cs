using BaseTemplate.Server4.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BaseTemplate.Server4
{
    public class ProgramBase
    {
        [DllImport("Kernel32")]
        protected static extern bool SetConsoleCtrlHandler(SetConsoleCtrlEventHandler handler, bool add);
        protected delegate bool SetConsoleCtrlEventHandler(CtrlType sig);
        protected static IMainService service;
        protected enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }
        protected static bool Handler(CtrlType signal)
        {
            switch (signal)
            {
                case CtrlType.CTRL_BREAK_EVENT:
                case CtrlType.CTRL_C_EVENT:
                case CtrlType.CTRL_LOGOFF_EVENT:
                case CtrlType.CTRL_SHUTDOWN_EVENT:
                case CtrlType.CTRL_CLOSE_EVENT:

                    // CODE HERE WHEN CLOSED
                    //Environment.Exit(0);
                    service.Stop();
                    Environment.Exit(0);
                    return false;

                default:
                    return false;
            }
        }
    }
}
