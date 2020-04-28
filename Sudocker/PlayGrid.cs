using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudocker
{
    public class PlayGrid
    {
        private readonly SmallGrid[] _smallGrids;

        public PlayGrid(SmallGrid [] smallGrids)
        {
            PlayGridValidator validator = new PlayGridValidator(smallGrids);

            validator.ValidateInitialState();

            _smallGrids = smallGrids;
        }
        
        public SmallGrid[] SmallGrids { get { return _smallGrids; } }

        public SmallGrid this[int index]
        {
            // The get accessor.
            get
            {
                return _smallGrids[index];
            }        
        }

        public int this[int gridnum, int index]
        {           
            set
            {
                _smallGrids[gridnum][index] = value;
            }
        }

        public int [] GetRow(int row)
        {
            if (row > 9 || row < 0)
            {
                throw new ArgumentException("row cannot be grater than 2");
            }

            var rowitems = _smallGrids.Skip(row * 3).Take(3).ToArray();

            return new int[] { };
        }

        protected PlayGrid Clone()
        {
            return (PlayGrid)this.MemberwiseClone();
        }

        protected SmallGrid[] CloneGrid()
        {
            IList<SmallGrid> items = new List<SmallGrid>();
            foreach(var item in _smallGrids)
            {
               items.Add((SmallGrid)item.Clone());
            }

            return items.ToArray();
        }

        public State [] GetPosibleStates(int x, int y)
        {
            var allPosible = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };     

            var subGridPossible = _smallGrids[x].GetPosibleNumbers();
          
            IList<State> ret = new List<State> { };

            foreach (var number in subGridPossible)
            {
                var smallGrids = this.CloneGrid();

                var subGrid = smallGrids[x];

                subGrid[y] = number;
                var state = new State(new PlayGrid(smallGrids));
                if(state.IsValidState())
                {
                    ret.Add(state);
                }              
            }

            return ret.ToArray();           
        }      
    }
}
