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
            this.elevatorsList = new List<Elevator>();
            this.callButtonsList = new List<CallButton>();

            createElevators(_amountOfFloors, _amountOfElevators);
            createCallbuttons(_amountOfFloors, _isBasement);
       }
        // creating my call buttons
       public void createCallbuttons(int _amountOfFloors, bool _isBasement)
       {
           
           if (_isBasement)
           {
               int buttonFloor = -1;
               for (int i = 0; i < _amountOfFloors; i++)
               {
                   CallButton callButton = new CallButton(Global.callButtonID, "off", buttonFloor, "Up");
                   this.callButtonsList.Add(callButton);
                   buttonFloor --;
                   Global.callButtonID ++;
               }
           }else 
           {
               int buttonFloor = 1;
               for (int i = 0; i < _amountOfFloors; i++)
               {
                   CallButton callButton = new CallButton(Global.callButtonID, "off", buttonFloor, "Down");
                   this.callButtonsList.Add(callButton);
                   buttonFloor ++;
                   Global.callButtonID ++;
               }
           }
       }

        // creating my elevator
       public void createElevators(int _amountOfFloors, int _amountOfElevators)
       {
           for ( int i = 0; i < _amountOfElevators; i++)
           {
               Elevator elevator = new Elevator(Global.elevatorID, "idle", _amountOfFloors, 1);
               this.elevatorsList.Add(elevator);
               Global.elevatorID ++;
           }
       }

       // to find the best elevator for the request
           public  Elevator findElevator(int floor, string direction)
           {
                BestElevatorInformation bestElevatorInformation = new BestElevatorInformation();
                bestElevatorInformation.bestElevator=  null;
                bestElevatorInformation.bestScore = 6;
                bestElevatorInformation.referenceGap = 10000000;
                // asking to go back to lobby
                if(floor == 1)
                {
                  foreach (Elevator elevator in this.elevatorsList)
                    {
                    
                
                        if (floor == elevator.currentFloor && elevator.status == "idle"){
                            bestElevatorInformation = this.checkIfElevatorIsBetter(1, elevator, bestElevatorInformation, floor);
                        }
                        else if (floor > elevator.currentFloor && elevator.direction == "up" && direction == elevator.direction)
                        {
                            bestElevatorInformation = this.checkIfElevatorIsBetter(2, elevator, bestElevatorInformation, floor);
                        }else if (floor < elevator.currentFloor && elevator.direction == "down" && direction == elevator.direction)
                        {
                            bestElevatorInformation = this.checkIfElevatorIsBetter(2, elevator, bestElevatorInformation, floor);
                        }
                        else if (elevator.status == "idle")
                        {
                            bestElevatorInformation = this.checkIfElevatorIsBetter(3, elevator, bestElevatorInformation, floor);
                        }
                        else
                        {
                            bestElevatorInformation = this.checkIfElevatorIsBetter(4, elevator, bestElevatorInformation, floor);
                        }
                        
                    }
                    return bestElevatorInformation.bestElevator;
                } 
                else  //asking to go to a floor
                {
                    foreach (Elevator elevator in this.elevatorsList)
                    {
                    
                
                        if (floor == elevator.currentFloor && elevator.status == "idle")
                        {
                            bestElevatorInformation = this.checkIfElevatorIsBetter(1, elevator, bestElevatorInformation, floor);
                        }
                        else if (floor > elevator.currentFloor && elevator.direction == "up" && direction == elevator.direction)
                        {
                            bestElevatorInformation = this.checkIfElevatorIsBetter(2, elevator, bestElevatorInformation, floor);
                        }
                        else if (floor < elevator.currentFloor && elevator.direction == "down" && direction == elevator.direction)
                        {
                            bestElevatorInformation = this.checkIfElevatorIsBetter(2, elevator, bestElevatorInformation, floor);
                        }
                        else if (elevator.status == "idle")
                        {
                            bestElevatorInformation = this.checkIfElevatorIsBetter(3, elevator, bestElevatorInformation, floor);
                        }
                        else
                        {
                            bestElevatorInformation = this.checkIfElevatorIsBetter(4, elevator, bestElevatorInformation, floor);
                        }
                        
                    }
                    return bestElevatorInformation.bestElevator;
                }
            }

        //checking witch elevator is better with the call BestElevatorInformation
        public BestElevatorInformation checkIfElevatorIsBetter(int scoreToCheck,Elevator newElevator, BestElevatorInformation bestElevatorInformation, int floor) 
        {
            
            if (scoreToCheck < bestElevatorInformation.bestScore)
            {
                bestElevatorInformation.bestScore = scoreToCheck;
                bestElevatorInformation.bestElevator = newElevator;
                bestElevatorInformation.referenceGap = Math.Abs(newElevator.currentFloor - floor);

            }
            else if (bestElevatorInformation.bestScore == scoreToCheck)
            {
                int gap = Math.Abs(newElevator.currentFloor - floor);
                if (bestElevatorInformation.referenceGap > gap)
                {
                    bestElevatorInformation.bestElevator = newElevator;
                    bestElevatorInformation.referenceGap = gap;
                }
            }
                
            return bestElevatorInformation;
        }

     
    }
}
