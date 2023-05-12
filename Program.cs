using System.Runtime.InteropServices;
using vmmsharp;

namespace Brookshook_DMA
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new main());
        }
    }
}