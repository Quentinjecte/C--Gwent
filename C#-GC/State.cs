using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C__GC
{
    public enum State 
    { 
        TopDown,
        Fight,
        Menu
    }
       public class StateManager
        {
            public State currentState;

            public StateManager()
            {
                currentState = State.TopDown;
            }

            public void ChangeState(State newState)
            {
                currentState = newState;
            }

            public State GetCurrentState()
            {
                return currentState;
            }
        }
}