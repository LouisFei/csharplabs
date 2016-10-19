using System;
using System.Diagnostics;

namespace TraceSourceSample
{
    class Program
    {
        private static TraceSource mySource = new TraceSource("TraceSourceApp");

        static void Main(string[] args)
        {
            mySource.Switch = new SourceSwitch("sourceSwitch", "Error");
            mySource.Listeners.Remove("Default");

            TextWriterTraceListener textListener = new TextWriterTraceListener("myListener.log");
            textListener.TraceOutputOptions = TraceOptions.DateTime | TraceOptions.Callstack;
            textListener.Filter = new EventTypeFilter(SourceLevels.Error);
            mySource.Listeners.Add(textListener);

            ConsoleTraceListener consoleListener = new ConsoleTraceListener(false);
            consoleListener.Filter = new EventTypeFilter(SourceLevels.Information);
            consoleListener.Name = "console";
            mySource.Listeners.Add(consoleListener);

            Activity1();

            mySource.Listeners["console"].Filter = new EventTypeFilter(SourceLevels.Critical);
            Activity2();

            mySource.Switch.Level = SourceLevels.All;

            mySource.Listeners["console"].Filter = new EventTypeFilter(SourceLevels.Information);
            Activity3();

            mySource.Close();
            Console.Read();
        }

        static void Activity1()
        {
            mySource.TraceEvent(TraceEventType.Error, 1, "Error message.");
            mySource.TraceEvent(TraceEventType.Warning, 2, "Warning message.");
        }

        static void Activity2()
        {
            mySource.TraceEvent(TraceEventType.Critical, 3, "Critical message.");
            mySource.TraceInformation("Informational message.");
        }

        static void Activity3()
        {
            mySource.TraceEvent(TraceEventType.Error, 4, "Error message.");
            mySource.TraceInformation("Informational message.");
        }
    }
}

/*
 http://www.cnblogs.com/luminji/archive/2010/10/26/1861316.html
 https://msdn.microsoft.com/zh-cn/library/system.diagnostics.tracesource(VS.90).aspx
     
     */
