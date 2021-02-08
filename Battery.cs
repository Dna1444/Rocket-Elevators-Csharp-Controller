using System;
using System.Collections; 
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CommercialController
{
    public class Battery
    {
        private int ID;
        public int amountOfColumns;
        public string status;
        public int amountOfFloors;
        public int amountOfBasements;
        public List<Column> columnList;
        public List<CallButton> callButtonsList;


        public Battery(int _id, int _amountOfColumns, string _status, int _amountOfFloors, int _amountOfBasements, int _amountOfElevatorPerColumn)
        {
            this.ID = _id;
            this.amountOfColumns = _amountOfColumns;
            this.status = _status;
            this.amountOfFloors = _amountOfFloors;
            this.amountOfBasements = _amountOfBasements;


            if (_amountOfBasements > 0)
            {
                createBasementFloorRequestButtons(this.amountOfBasements);
                createBasementColumn(this.amountOfBasements, _amountOfElevatorPerColumn);
                this.amountOfColumns --;
            }
            createFloorRequestButtons(this.amountOfFloors);
            createColumns(this.amountOfColumns, this.amountOfFloors, _amountOfElevatorPerColumn);


        }

        static void createBasementColumn(int amountOfBasements, int _amountOfElevatorPerColumn)
        {
            public List<int> servedFloors;
            // int numBasement = amountOfBasements;
            int floor = -1;
            for ( int i = 0; i < this.amountOfBasements; i++)
            {

            }

        }


    }
}
