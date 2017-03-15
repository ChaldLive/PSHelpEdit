using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PSHelpEdit.Keys
{
    public static partial class ResourceKeys
    {
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        private static ResourceKey CreateInstance(string keyID)
        {
            return new ComponentResourceKey(typeof(UIElement), keyID);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        private static ComponentResourceKey CreateInstanceEx(string keyID)
        {
            return new ComponentResourceKey(typeof(UIElement), keyID);
        }
    }
}
