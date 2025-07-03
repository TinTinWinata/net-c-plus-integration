using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CounterTest.Service
{
    internal class CounterWrapper : IDisposable
    {
        private const string COUNTER_LIB_DLL_PATH = "CounterLib.dll";

        [DllImport(COUNTER_LIB_DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CreateCounter(int value);

        [DllImport(COUNTER_LIB_DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern void DisposeCounter(IntPtr counterPointer);

        [DllImport(COUNTER_LIB_DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern void IncrementCounter(IntPtr counterPointer);

        [DllImport(COUNTER_LIB_DLL_PATH, CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetCounterValue(IntPtr counterPointer);

        private IntPtr _counterPointer;

        public CounterWrapper(int initialValue)
        {
            _counterPointer = CreateCounter(initialValue);
            if (_counterPointer == IntPtr.Zero)
            {
                throw new InvalidOperationException("Failed to create counter.");
            }
        }
        public int GetValue()
        {
            return GetCounterValue(_counterPointer);
        }
        public void Increment()
        {
            IncrementCounter(_counterPointer);
        }
        public void Dispose()
        {
            DisposeCounter(_counterPointer);
        }
    }
}
