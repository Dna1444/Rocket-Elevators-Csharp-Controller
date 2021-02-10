using System;
using System.Collections; 
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommercialController
{
    public class Elevator
    {
        public int ID;
        public string status;
        public int amountOfFloors;
        public int currentFloor;
        public List<int> floorRequestList;
        public string direction;
        public Door door;

        // my contructor
        public Elevator(int _id, string _status, int _amountOfFloors, int _currentFloor)
        {
            this.ID = _id;
            this.status = _status;
            this.amountOfFloors = _amountOfFloors;
            this.currentFloor = _currentFloor;
            this.door = new Door(_id, "close");
            this.floorRequestList = new List<int>();
            this.direction = "none";
            
        }
        

        // moving the elevator to the right floor
        public void move()
        {
            while (this.floorRequestList.Count != 0)
            {
                int destination = this.floorRequestList[0];
                this.status = "moving";
                //console.log("elevator" + this.ID + " is moving")
                System.Console.WriteLine("elevator {0} is moving", this.ID);
                if (this.currentFloor < destination)  // if statement so if the elevator need to go up it will 
                {
                    //console.log("elevator going up")
                    System.Console.WriteLine("elevator {0} is going up", this.ID);
                    this.direction = "up";
                    while (this.currentFloor < destination)
                    {
                        this.currentFloor ++;
                        //console.log("elevator" + this.ID + " moving to floor" + this.currentFloor,)
                        System.Console.WriteLine("elevator {0} moving to floor {1}", this.ID, this.currentFloor);
                    }
                }
                else if (this.currentFloor > destination)
                {
                    //console.log("elevator going down")
                    System.Console.WriteLine("elevator {0} is going down", this.ID);
                    this.direction = "down";
                    while (this.currentFloor > destination)
                    {
                        this.currentFloor --;
                        System.Console.WriteLine("elevator {0} moving to floor {1}", this.ID, this.currentFloor);
                        //console.log("elevator" + this.ID + " moving to floor" + this.currentFloor,)
                    }
                }
                
                this.status = "idle";
                this.direction = "null";
                System.Console.WriteLine("elevator {0} is stopped", this.ID);
                this.operateDoors();  // operate door once finish moving
                //console.log("elevator " + this.ID + " is stopped" )
                this.floorRequestList.RemoveAt(0);
            
            }
        }

        // my sorting list 
        public void sortFloorList(string going)
        {
            //using lobby to tell that the request is from lobby and change the way it sorted
            if (going == "lobby") 
            {
                if (this.direction == "Down")
                {
                    //System.Console.WriteLine("normal sort");
                    this.floorRequestList.Sort(); 
                }
                else
                {
                    //System.Console.WriteLine("reverse sort");
                    this.floorRequestList.Sort();
                    this.floorRequestList.Reverse();
                }
            }
            // not from lobby use this way of sorting
            else if (going == "not")  
            {
                if (this.direction == "Up")
                {
                    //System.Console.WriteLine("normal sort");
                    this.floorRequestList.Sort(); 
                }
                else
                {
                    //System.Console.WriteLine("reverse sort");
                    this.floorRequestList.Sort();
                    this.floorRequestList.Reverse();
                }
            }
        
        }


        // a simple way to open and close doors
        public void operateDoors()
        {

            this.door.status = "open";
            System.Console.WriteLine("door is {0}", this.door.status);
            //console.log(this.door.status + "door")
            //console.log("please wait 5 seconds")
            System.Console.WriteLine("please wait 5 seconds");
            this.door.status = "close";
            System.Console.WriteLine("door is {0}", this.door.status);
            //console.log(this.door.status + "door")
        }

    
    }
}
