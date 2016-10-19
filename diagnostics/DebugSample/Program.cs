using System;
using System.Diagnostics;

namespace DebugSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Debug.AutoFlush = true;
            Debug.Indent();
            Debug.WriteLine("Entering Main");
            Console.WriteLine("Hello World.");
            Debug.WriteLine("Exiting Main");
            Debug.Unindent();

            Console.Read();
        }
    }
}

/*
 https://msdn.microsoft.com/zh-cn/library/system.diagnostics.debug(VS.90).aspx

     */
