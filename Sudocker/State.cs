using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudocker
{
    public class State
    {
        private readonly PlayGrid _grid;
        private const int COL_ROW_SUM = 45;

        public State(PlayGrid grid)
        {
            _grid = grid;
        }

        public PlayGrid Grid { get { return _grid; } }

        protected bool CheckSumRows()
        {
            for (int i = 0; i < 9;)
            {
                var grid1 = _grid.SmallGrids[i];
                var grid2 = _grid.SmallGrids[i+1];
                var grid3 = _grid.SmallGrids[i+2];

                for (int j=0; j< 3; j++)
                {
                    var row1 = grid1.GetRow(j);
                    var row2 = grid2.GetRow(j);
                    var row3 = grid3.GetRow(j);

                    if(row1.Sum() + row2.Sum() + row3.Sum() != COL_ROW_SUM)
                    {
                        return false;
                    }
                }

                i += 3;
            }

            return true;
        }

        protected bool CheckSumColums()
        {
            for (int i = 0; i < 3;)
            {
                var grid1 = _grid.SmallGrids[i];
                var grid2 = _grid.SmallGrids[i + 3];
                var grid3 = _grid.SmallGrids[i + 6];

                for (int j = 0; j < 3; j++)
                {
                    var col1 = grid1.GetColumn(j);
                    var col2 = grid2.GetColumn(j);
                    var col3 = grid3.GetColumn(j);

                    if (col1.Sum() + col2.Sum() + col3.Sum() != COL_ROW_SUM)
                    {
                        return false;
                    }
                }
                i +=1;
            }

            return true;
        }

        protected bool AreRowsUnique()
        {
            for (int i = 0; i < 9;)
            {
                var grid1 = _grid.SmallGrids[i];
                var grid2 = _grid.SmallGrids[i + 1];
                var grid3 = _grid.SmallGrids[i + 2];

                for (int j = 0; j < 3; j++)
                {
                    var row1 = grid1.GetRow(j);
                    var row2 = grid2.GetRow(j);
                    var row3 = grid3.GetRow(j);

                    var all = row1.All.Concat(row2.All).Concat(row3.All).Where(x => x != -1);

                    if (all.Distinct().Count() != all.Count())
                    {
                        return false;
                    }
                }

                i += 3;
            }

            return true;
        }

        protected bool AreColsUnique()
        {
            for (int i = 0; i < 3;)
            {
                var grid1 = _grid.SmallGrids[i];
                var grid2 = _grid.SmallGrids[i + 3];
                var grid3 = _grid.SmallGrids[i + 6];

                for (int j = 0; j < 3; j++)
                {
                    var col1 = grid1.GetColumn(j);
                    var col2 = grid2.GetColumn(j);
                    var col3 = grid3.GetColumn(j);

                    var all = col1.All.Concat(col2.All).Concat(col3.All).Where(x => x != -1);

                    if (all.Distinct().Count() != all.Count())
                    {
                        return false;
                    }
                }
                i += 1;
            }

            return true;
        }

        public bool IsValidState()
        {
            return AreColsUnique() && 
                AreRowsUnique();
        }

        public bool IsSumValid()
        {
            return CheckSumRows() && 
                CheckSumColums();
        }

        public bool IsFinal()
        {
            var grids = _grid.SmallGrids;

            return grids.All(x => x.IsCompleted()) && IsSumValid();
        }

    }
}
