using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudocker
{
    public class BackTracking
    {
        Stack<State> _steps;
        State _initial;

        public BackTracking(PlayGrid grid)
        {
            _steps = new Stack<State>();

            _initial = new State(grid);        
        }

        public State Find()
        {
           return BFSIncrement(_initial);
        }

        private State BFSIncrement(State state)
        {
            if (state.IsFinal())
            {
                return state;
            }
            else
            {
                var grid = state.Grid;

                bool stateFound = false;

                for (int i = 0; i < state.Grid.SmallGrids.Length; i++)
                {
                    var smallGrid = state.Grid[i];
                    if (stateFound)
                        break;

                    for (int j = 0; j < smallGrid.GetGridItems().Length; j++)
                    {
                        if (smallGrid.IsFull())
                            break;

                        if (smallGrid[j] == -1)
                        {
                            stateFound = true;
                            var newStates = grid.GetPosibleStates(i, j);

                            if (!newStates.Any())
                            {
                                break;
                            }

                            foreach (var s in newStates)
                            {
                                BFSIncrement(s);
                            }

                            break;
                        }

                    }
                }
            }

            return null;           
        }
    }
}
