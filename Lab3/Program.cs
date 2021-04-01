using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            [DllImport("winmm.dll")]
            private static extern int mciSendString(string strCommand,
        StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
            [DllImport("winmm.dll")]
            public static extern int mciGetErrorString(int errCode,
                          StringBuilder errMsg, int buflen);
        }
    }
}
