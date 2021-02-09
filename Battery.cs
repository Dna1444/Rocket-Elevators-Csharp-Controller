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
        public List<LobbyCallButton> callButtonsList;
        public int columnId = 1;
        


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
                createBasementColumn(_amountOfBasements, _amountOfElevatorPerColumn);
                this.amountOfColumns --;
            }
            createFloorRequestButtons(this.amountOfFloors);
            createColumns(this.amountOfColumns, this.amountOfFloors, _amountOfElevatorPerColumn);


        }

        public void createBasementColumn(int _amountOfBasements, int _amountOfElevatorPerColumn)
        {
            List<int> servedFloors = new List<int>();
            // int numBasement = _amountOfBasements;
            int floor = -1;
            for ( int i = 0; i < _amountOfBasements; i++)
            {
        
                servedFloors.Add(floor);
                floor --;
            }
            
            Column column = new Column(this.columnId, "online", this.amountOfBasements, _amountOfElevatorPerColumn, servedFloors, true);
            columnList.Add(column);
            this.columnId ++;

        }


    }
}
