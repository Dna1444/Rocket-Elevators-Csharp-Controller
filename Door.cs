using System;
using System.Collections; 
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommercialController
{
    public class Door
    {
        public int ID;
        public string status;
        public Door(int _id, string _status)
        {
            this.ID = _id;
            this.status = _status;
        }
    }
}
