using System;
using System.Diagnostics;

namespace BooleanSwitchSample
{
    class Program
    {
        /* Create a BooleanSwitch for data.*/
        static BooleanSwitch dataSwitch = new BooleanSwitch("Data", "DataAccess module");

        static public void MyMethod(string location)
        {
            //Insert code here to handle processing.
            if (dataSwitch.Enabled)
                Console.WriteLine("Error happened at " + location);
        }
        static void Main(string[] args)
        {
            //Run the method which writes an error message specifying the location of the error.
            MyMethod("in Main");

            Console.Read();
        }
    }
}
