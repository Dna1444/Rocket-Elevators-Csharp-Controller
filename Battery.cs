using System;
using System.Collections; 
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CommercialController
{
    public class Battery
    {
        public int ID;
        public int amountOfColumns;
        public string status;
        public int amountOfFloors;
        public int amountOfBasements;
        public List<Column> columnList;
        public List<FloorRequestButton> floorButtonsList;
        public List<int> servedFloors;
        
        


        public Battery(int _id, int _amountOfColumns, string _status, int _amountOfFloors, int _amountOfBasements, int _amountOfElevatorPerColumn)
        {
            this.ID = _id;
            this.amountOfColumns = _amountOfColumns;
            this.status = _status;
            this.amountOfFloors = _amountOfFloors;
            this.amountOfBasements = _amountOfBasements;
            this.columnList = new List<Column>();
            this.floorButtonsList = new List<FloorRequestButton>();


            if (_amountOfBasements > 0)
            {
                createBasementFloorRequestButtons(this.amountOfBasements);
                createBasementColumn(_amountOfBasements, _amountOfElevatorPerColumn);
                this.amountOfColumns --;
            }
            createFloorRequestButtons(this.amountOfFloors);
            createColumns(this.amountOfColumns, this.amountOfFloors, _amountOfElevatorPerColumn);


        }
        // create my basement column
        public void createBasementColumn(int _amountOfBasements, int _amountOfElevatorPerColumn)
        {
            this.servedFloors = new List<int>();
            int floor = -1;
            for ( int i = 0; i < _amountOfBasements; i++)
            {
        
                servedFloors.Add(floor);
                floor --;
            }
            
            Column column = new Column(Global.columnID, "online", this.amountOfBasements, _amountOfElevatorPerColumn, servedFloors, true);
            columnList.Add(column);
            Global.columnID ++;

        }
        // create my up ground columns
        public void createColumns(int _amountOfColumns, int _amountOfFloors, int _amountOfElevatorPerColumn)
        {
            int amountOfFloorsPerColumn = (int)Math.Ceiling((double)_amountOfFloors / _amountOfColumns);
            int floor = 1;
            for ( int i = 0; i < _amountOfColumns; i ++)
            {
                this.servedFloors = new List<int>();
                for (int j = 0 ; j < amountOfFloorsPerColumn; j ++)
                {
                    if(floor <= _amountOfFloors)
                    {
                        if(floor != 1)
                        {
                            this.servedFloors.Add(1);
                        }
                        this.servedFloors.Add(floor);
                        floor++;
                    }
                }
                Column column = new Column(Global.columnID, "online", this.amountOfBasements, _amountOfElevatorPerColumn, servedFloors, false);
                this.columnList.Add(column);
                Global.columnID++;
            }
        }

        // making my floor request list
        public void createFloorRequestButtons( int _amountOfFloors)
        {
            int buttonFloor = 1;
            for (int i = 0; i < _amountOfFloors; i++)
            {
                FloorRequestButton floorRequestButton = new FloorRequestButton(Global.floorRequestButtonID, "off", buttonFloor, "Up");
                this.floorButtonsList.Add(floorRequestButton);
                buttonFloor ++;
                Global.floorRequestButtonID ++;
            }
        }
        

        //make m y floor request list for basement
        public void createBasementFloorRequestButtons(int _amountOfBasements)
        {
            int buttonFloor = -1;
            for( int i = 0; i < _amountOfBasements; i++)
            {
                 FloorRequestButton floorRequestButton = new FloorRequestButton(Global.floorRequestButtonID, "off", buttonFloor, "Down");
                 this.floorButtonsList.Add(floorRequestButton);
                 buttonFloor --;
                 Global.floorRequestButtonID ++;
            }
        }   

        // // to pick the column that serve that floor
        public Column findBestColumn(int _requestFloor)
        {
            Column bestColumn = null;
            foreach (Column column in this.columnList)
            {
                if (column.servedFloorsList.Contains(_requestFloor))
                {
                    bestColumn = column;
                    

                }
                
            }
            return bestColumn;
        }
        
        // chosing the elevator for the request
        public void assignElevator(int _requestFloor, string direction)
        {
            string going = "looby";
            Column column = this.findBestColumn(_requestFloor);
            System.Console.WriteLine( "column {0}", column.ID);
            Elevator elevator = column.findElevator(1, direction);
            System.Console.WriteLine("elevator {0}",elevator.ID);
            //elevator.floorRequestList.Add(1);
            //elevator.move();
            elevator.floorRequestList.Add(_requestFloor);
            elevator.sortFloorList(going);
            elevator.move();
            
        }
    

    }
}
