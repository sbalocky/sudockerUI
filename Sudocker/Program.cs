using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudocker
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid1 = new SmallGrid(new int[9] { 5, 3, -1 , 6, -1, -1, -1, 9, 8 });
            var grid2 = new SmallGrid(new int[9] { -1, 7, -1, 1, 9, 5, -1, -1, -1 });
            var grid3 = new SmallGrid(new int[9] { -1, -1, -1, -1, -1, -1, -1, 6, -1 });

            var grid4 = new SmallGrid(new int[9] { 8, -1, -1, 4, -1, -1, 7, -1, -1 });
            var grid5 = new SmallGrid(new int[9] { -1, 6, -1, 8, -1, 3, -1, 2, -1 });
            var grid6 = new SmallGrid(new int[9] { -1, -1, 3, -1, -1, 1, -1, -1, 6 });

            var grid7 = new SmallGrid(new int[9] { -1, 6, -1, -1, -1, -1, -1, -1, -1 });
            var grid8 = new SmallGrid(new int[9] { -1, -1, -1, 4, 1, 9, -1, 8, -1 });
            var grid9 = new SmallGrid(new int[9] { 2, 8, -1, -1, -1, 5, -1, 7, 9 });
          

            var playGrid = new PlayGrid(new SmallGrid[] { grid1, grid2, grid3, grid4, grid5, grid6, grid7, grid8, grid9 });

             new BackTracking(playGrid).Find();

        }
    }
}
