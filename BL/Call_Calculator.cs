using System.Runtime.InteropServices;

namespace BL
{
    public class Call_Calculator
    {
        [DllImport("C:/Qt/FortranInterop/Interop.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "__interop_MOD_sum_integer")]
        public static extern int SumInteger(ref int a, ref int b);


    }
}
