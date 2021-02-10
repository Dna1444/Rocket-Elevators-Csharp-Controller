using System;
using System.Collections; 
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommercialController
{
    class Program
    {
        public static void Senario1()
            {
                Battery battery = new Battery( 1, 4, "online", 60, 6, 5);
                battery.columnList[1].elevatorsList[0].currentFloor = 20;
                battery.columnList[1].elevatorsList[0].status = "moving";
                battery.columnList[1].elevatorsList[0].direction = "Down";
                battery.columnList[1].elevatorsList[0].floorRequestList.Add(5);
                battery.columnList[1].elevatorsList[1].currentFloor = 3;
                battery.columnList[1].elevatorsList[1].status = "moving";
                battery.columnList[1].elevatorsList[1].direction = "Up";
                battery.columnList[1].elevatorsList[1].floorRequestList.Add(15);
                battery.columnList[1].elevatorsList[2].currentFloor = 13;
                battery.columnList[1].elevatorsList[2].status = "moving";
                battery.columnList[1].elevatorsList[2].direction = "Down";
                battery.columnList[1].elevatorsList[2].floorRequestList.Add(1);
                battery.columnList[1].elevatorsList[3].currentFloor = 15;
                battery.columnList[1].elevatorsList[3].status = "moving";
                battery.columnList[1].elevatorsList[3].direction = "Down";
                battery.columnList[1].elevatorsList[3].floorRequestList.Add(2);
                battery.columnList[1].elevatorsList[4].currentFloor = 6;
                battery.columnList[1].elevatorsList[4].status = "moving";
                battery.columnList[1].elevatorsList[4].direction = "Down";
                battery.columnList[1].elevatorsList[4].floorRequestList.Add(1);
                
                battery.assignElevator(20, "Up");


            }
            public static void Senario2()
            {
                Battery battery = new Battery( 1, 4, "online", 60, 6, 5);
                battery.columnList[2].elevatorsList[0].currentFloor = 1;
                battery.columnList[2].elevatorsList[0].status = "idle";
                battery.columnList[2].elevatorsList[0].direction = "Up";
                battery.columnList[2].elevatorsList[0].floorRequestList.Add(21);
                battery.columnList[2].elevatorsList[1].currentFloor = 23;
                battery.columnList[2].elevatorsList[1].status = "moving";
                battery.columnList[2].elevatorsList[1].direction = "Up";
                battery.columnList[2].elevatorsList[1].floorRequestList.Add(28);
                battery.columnList[2].elevatorsList[2].currentFloor = 33;
                battery.columnList[2].elevatorsList[2].status = "moving";
                battery.columnList[2].elevatorsList[2].direction = "Down";
                battery.columnList[2].elevatorsList[2].floorRequestList.Add(1);
                battery.columnList[2].elevatorsList[3].currentFloor = 40;
                battery.columnList[2].elevatorsList[3].status = "moving";
                battery.columnList[2].elevatorsList[3].direction = "Down";
                battery.columnList[2].elevatorsList[3].floorRequestList.Add(24);
                battery.columnList[2].elevatorsList[4].currentFloor = 39;
                battery.columnList[2].elevatorsList[4].status = "moving";
                battery.columnList[2].elevatorsList[4].direction = "Down";
                battery.columnList[2].elevatorsList[4].floorRequestList.Add(1);
                
                battery.assignElevator(36, "Up");


            }

            public static void Senario3()
            {
                Battery battery = new Battery( 1, 4, "online", 60, 6, 5);
                battery.columnList[3].elevatorsList[0].currentFloor = 58;
                battery.columnList[3].elevatorsList[0].status = "moving";
                battery.columnList[3].elevatorsList[0].direction = "Down";
                battery.columnList[3].elevatorsList[0].floorRequestList.Add(1);
                battery.columnList[3].elevatorsList[1].currentFloor = 50;
                battery.columnList[3].elevatorsList[1].status = "moving";
                battery.columnList[3].elevatorsList[1].direction = "Up";
                battery.columnList[3].elevatorsList[1].floorRequestList.Add(60);
                battery.columnList[3].elevatorsList[2].currentFloor = 46;
                battery.columnList[3].elevatorsList[2].status = "moving";
                battery.columnList[3].elevatorsList[2].direction = "Up";
                battery.columnList[3].elevatorsList[2].floorRequestList.Add(58);
                battery.columnList[3].elevatorsList[3].currentFloor = 1;
                battery.columnList[3].elevatorsList[3].status = "moving";
                battery.columnList[3].elevatorsList[3].direction = "Up";
                battery.columnList[3].elevatorsList[3].floorRequestList.Add(54);
                battery.columnList[3].elevatorsList[4].currentFloor = 60;
                battery.columnList[3].elevatorsList[4].status = "moving";
                battery.columnList[3].elevatorsList[4].direction = "Down";
                battery.columnList[3].elevatorsList[4].floorRequestList.Add(1);

                for(int i = 0; i < battery.columnList[3].elevatorsList[4].floorRequestList.Count; i++ )
            {
                System.Console.WriteLine(battery.columnList[3].elevatorsList[4].floorRequestList[i]);
            }
                
                battery.columnList[3].requestElevator(51, "Down");


            }
        static void Main(string[] args)
        {
           Senario3();
        //    Battery battery = new Battery( 1, 4, "online", 60, 6, 5);
        //    System.Console.WriteLine(battery.columnList[3].servedFloorsList[1]);



            
            //             Floors deserved:
            // Column A: B6 to B1 + RC 
            // Column B: 2 to 20 + RC 
            // Column C: 21 to 40 + RC
            // Column D: 41 to 60 + RC

            // Scenario 1:
            // Elevator B1 at 20th floor going to the 5th floor
            // Elevator B2 at 3rd floor going to the 15th floor
            // Elevator B3 at 13th floor going to RC
            // Elevator B4 at 15th floor going to the 2nd floor
            // Elevator B5 at 6th floor going to RC

            // Someone at RC wants to go to the 20th floor.
            // Elevator B5 is expected to be sent.


           // System.Console.WriteLine(elevator.ID);    
            //         Scenario 1:
            // Elevator B1 at 20th floor going to the 5th floor
            // Elevator B2 at 3rd floor going to the 15th floor
            // Elevator B3 at 13th floor going to RC
            // Elevator B4 at 15th floor going to the 2nd floor
            // Elevator B5 at 6th floor going to RC

            // Someone at RC wants to go to the 20th floor.
            // Elevator B5 is expected to be sent.

        }
    }
}
