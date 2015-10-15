using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Semaphore
{
    enum TrafficLightState { RED, YELLOW, GREEN}    //Enumerator for the states
    
    public class TrafficLights
    {
        private TrafficLightState StateN { get; set; }  // State of N Traffic light - this one is used in calculations, and SetLightsFromN is used to set the other lights based on this property
        private TrafficLightState StateW { get; set; }  // State of W Traffic light
        private TrafficLightState StateS { get; set; }  // State of S Traffic light
        private TrafficLightState StateE { get; set; }  // State of E Traffic light        
        private int secondsCounter {get;set;} // Counter of the seconds
        private int LengthOfLight {get;set;} // Length of light in seconds (300 seconds)
        private int LengthOfYellow {get; set;} //Length of yellow light in seconds (30 seconds)
        private bool DirectionFromRedToGreen { get; set; } // This boolean value determines where should the light go after yellow light

        //constructor... gives flexibility to change the lengths
        public TrafficLights(int lengthLight, int lengthYellow)
        { 
            secondsCounter = 0;
            LengthOfLight = lengthLight;
            LengthOfYellow = lengthYellow;
            SetStateN(TrafficLightState.RED); // Initial state
        }

        // Sets the StateN and calls the next method
        private void SetStateN(TrafficLightState state)
        {
            StateN = state;
            SetLightsFromN();
        }

        // used to set the other lights based on StateN
        private void SetLightsFromN()
        {
            StateS = StateN;
            switch (StateN)
            {
                case TrafficLightState.RED:
                    StateE = StateW = TrafficLightState.GREEN;
                    break;
                case TrafficLightState.YELLOW:
                    StateE = StateW = TrafficLightState.YELLOW;
                    break;
                case TrafficLightState.GREEN:
                    StateE = StateW = TrafficLightState.RED;
                    break;
            }
        } 

        // performs moving one second forward in time and calculating the states
        public void MoveOneSecond()
        {
            secondsCounter++;
            switch (StateN)
            {
                case TrafficLightState.RED:
                    if (secondsCounter == LengthOfLight)
                    {
                        secondsCounter = 0;
                        DirectionFromRedToGreen = true;
                        SetStateN(TrafficLightState.YELLOW);
                    }
                    break;
                case TrafficLightState.YELLOW:
                    if (secondsCounter == LengthOfYellow)
                    {
                        secondsCounter = 0;
                        if (DirectionFromRedToGreen)
                            SetStateN(TrafficLightState.GREEN);
                        else
                            SetStateN(TrafficLightState.RED);
                    }
                    break;
                case TrafficLightState.GREEN:
                    if (secondsCounter == LengthOfLight)
                    {
                        secondsCounter = 0;
                        DirectionFromRedToGreen = false;
                        SetStateN(TrafficLightState.YELLOW);
                    }
                    break;
            }
        }

        // returns the current states of the traffic lights
        public string CurrentStates()
        {
            return StateN.ToString() + "\t" + StateW.ToString() + "\t" + StateS.ToString() + "\t" + StateE.ToString();
        }

    }
}
