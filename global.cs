using System;
using System.Collections; 
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommercialController
{

    // making my id global so i can change them only when called and to make sure every thing has a unique ID, so no elevator has the same ID
    static class Global
    {
        public static int elevatorID = 1;
        public static int columnID = 1;
        public static int floorRequestButtonID = 1;
        public static int callButtonID = 1;

        
    }
}
