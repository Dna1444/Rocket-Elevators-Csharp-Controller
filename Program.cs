using System;
using System.Collections; 
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommercialController
{
    class Program
    {
        static void Main(string[] args)
        {
            Battery battery = new Battery( 1, 4, "online", 60, 6, 5);
            Console.WriteLine(battery);
        }
    }
}
