using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vmmsharp;

namespace Brookshook_DMA
{
    public static class Data
    {
        public static Vmm VmmHandle { get; set; }
        public static uint CsgoPid { get; set; }
        public static uint ClientDll { get; set; }
        public static uint EngineDll { get; set; }
        public enum Maps
        {
            Ancient,
            Cache,
            Dust2,
            Inferno,
            Mirage,
            Nuke,
            Overpass,
            Train,
            Vertigo
        }
    }
}
