using System;
using System.Collections; 
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommercialController
{
    public class Column
    {
        private int ID;
        public string status;
        public int amountOfFloors;
        public int amountOfElevators;
        public List<Elevator> elevatorsList;
        public List<CallButton> callButtonsList;
        public List<int> servedFloorsList;
        public int callButtonId = 1;


       public Column(int _id, string _status, int _amountOfFloors, int _amountOfElevators, List<int> _servedFloors, bool _isBasement)
       {
            this.ID = _id;
            this.status = _status;
            this.amountOfFloors = _amountOfFloors;
            this.amountOfElevators = _amountOfElevators;
            this.servedFloorsList = _servedFloors;

            createElevators(_amountOfFloors, _amountOfElevators);
            createCallbuttons(_amountOfFloors, _isBasement);
       }

       public void createCallbuttons(int _amountOfFloors, bool _isBasement)
       {
           
           if (_isBasement)
           {
               int buttonFloor = -1;
               for (int i = 0; i < _amountOfFloors; i++)
               {
                   CallButton callButton = new CallButton(this.callButtonId, "off", buttonFloor, "Up");
                   callButtonsList.Add(callButton);
                   buttonFloor --;
                   this.callButtonId ++;
               }
           }else 
           {
               int buttonFloor = 1;
               for (int i = 0; i < _amountOfFloors; i++)
               {
                   CallButton callButton = new CallButton(this.callButtonId, "off", buttonFloor, "Down");
                   callButtonsList.Add(callButton);
                   buttonFloor ++;
                   this.callButtonId ++;
               }
           }
       }

       public void createElevators(int _amountOfFloors, int _amountOfElevators)
       {
           for ( int i = 0; i < _amountOfElevators; i++)
           {
               Elevator elevator = new Elevator(Global.elevatorID,   )
           }
       }
    }
}
