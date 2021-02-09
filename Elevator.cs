using System;
using System.Collections; 
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommercialController
{
    public class Elevator
    {
        int ID;
        string status;
        int amountOfFloors;
        int currentfloor;
        List<int> floorRequestList;
        public Elevator(int _id, string _status, int _amountOfFloors, int _currentfloor)
        {
            this.ID = _id;
            this.status = _status;
            this.amountOfFloors = _amountOfFloors;
            this.currentfloor = _currentfloor;
            Door door = new Door(_id, "close");
            this.floorRequestList = new List<int>();
            
        }

        
    }
}
