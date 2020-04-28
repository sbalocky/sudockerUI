using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudocker
{
    public class SmallGrid
    {
        int[] gridItems;

        SmallGridValidator validator;
                   
        public SmallGrid(int [] source)
        {

            this.validator = new SmallGridValidator(source);

            this.validator.ValidateInitialState();

            this.gridItems = source;         
        }

        public int this[int index]
        {
            // The get accessor.
            get
            {
                return gridItems[index];
            }
            set
            {
                gridItems[index] = value;
            }
        }

        public int [] GetGridItems()
        {
            return this.gridItems;
        }

        public bool IsCompleted()
        {
            return this.gridItems.All(x => x > 0 && x <=9) 
                && this.gridItems.Length == 9
                && this.gridItems.Sum() == 45;
        }

        public int [] GetPosibleNumbers()
        {
            var allPosible = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            return allPosible.Except(this.gridItems.Where(x=> x != -1)).ToArray();
        }

        public Triplet GetRow(int row)
        {
            if(row>2 || row< 0)
            {
                throw new ArgumentException("row cannot be grater than 2");
            }           

            var rowitems = gridItems.Skip(row * 3).Take(3).ToArray();

            return new Triplet(rowitems[0], rowitems[1], rowitems[2]);
        }

        public SmallGrid Clone()
        {
            return new SmallGrid((int [])gridItems.Clone());        
        }

        public bool IsFull()
        {
            return this.gridItems.All(x => x > -1 && x <= 9);
        }

        public Triplet GetColumn(int column)
        {
            if (column > 2 || column < 0)
            {
                throw new ArgumentException("column cannot be grater than 2");
            }

            IList<int> ret = new List<int>();                   
            
            for(int i = column; i<this.gridItems.Length; i++)
            {                
                var item = this.gridItems[i];        

                if(i % 3 == column)
                {
                    ret.Add(item);
                }
            }

            var col = ret.ToArray();

            return new Triplet(col[0], col[1], col[2]);
        }

    }
}
