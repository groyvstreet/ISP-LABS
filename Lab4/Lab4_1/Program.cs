using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Lab4_1
{
    [StructLayout(LayoutKind.Sequential)]
    struct SystemInfo
    {
        public ushort wProcessorArchitecture;
        public ushort wReserved;
        public uint dwPageSize;
        public IntPtr lpMinimumApplicationAddress;
        public IntPtr lpMaximumApplicationAddress;
        public IntPtr dwActiveProcessorMask;
        public uint dwNumberOfProcessors;
        public uint dwProcessorType;
        public uint dwAllocationGranularity;
        public ushort wProcessorLevel;
        public ushort wProcessorRevision;
    }
    enum ProcessorArchitecture
    {
        x86 = 0,
        ARM = 5,
        IA64 = 6,
        x64 = 9,
        ARM64 = 12,
        Unknown = 65535
    }
    enum ProcessorType
    {
        Intel386 = 386,
        Intel486 = 486,
        IntelPentium = 586,
        IntelIA64 = 2200,
        AMD = 8664
    }
    class Program
    {
        [DllImport("kernel32.dll")]
        public static extern int GetComputerName(StringBuilder buffer, ref int sizeBuffer);
        [DllImport("kernel32.dll")]
        static extern void GetNativeSystemInfo(out SystemInfo Info);
        [DllImport("kernel32.dll")]
        static extern bool GetPhysicallyInstalledSystemMemory(out long memory);

        static void Main()
        {
            StringBuilder computerName = new StringBuilder(20);
            int length = computerName.Capacity;
            GetComputerName(computerName, ref length);
            Console.WriteLine($"Information about {computerName}: \n");
            GetNativeSystemInfo(out SystemInfo info);
            Console.WriteLine($"Processor architecture: {(ProcessorArchitecture)info.wProcessorArchitecture}");
            Console.WriteLine($"Reserved: {info.wReserved}");
            Console.WriteLine($"Page size: {info.dwPageSize}");
            Console.WriteLine($"Minimum application address: {info.lpMinimumApplicationAddress}");
            Console.WriteLine($"Maximum application address: {info.lpMaximumApplicationAddress}");
            Console.WriteLine($"Active processor mask: {info.dwActiveProcessorMask}");
            Console.WriteLine($"Number of processors: {info.dwNumberOfProcessors}");
            Console.WriteLine($"Processor type: {(ProcessorType)info.dwProcessorType}");
            Console.WriteLine($"Allocation granularity: {info.dwAllocationGranularity}");
            Console.WriteLine($"Processor level: {info.wProcessorLevel}");
            Console.WriteLine($"Processor revision: {info.wProcessorRevision}");
            GetPhysicallyInstalledSystemMemory(out long memory);
            Console.WriteLine($"RAM: {memory / 1024 / 1024} GB");
        }
    }
}
