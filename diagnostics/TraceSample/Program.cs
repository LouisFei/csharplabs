using System;
using System.Diagnostics;

namespace TraceSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;
            Trace.Indent();
            Trace.WriteLine("Entering Main");
            Console.WriteLine("Hello World.");
            Trace.WriteLine("Exiting Main");
            Trace.Unindent();

            Console.ReadKey();

        }
    }
}
/*
 https://msdn.microsoft.com/zh-cn/library/system.diagnostics.trace(VS.90).aspx

 */
