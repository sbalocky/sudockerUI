using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudockerWebApi.Dtos
{
    public class SmallGridDto
    {
        public SmallGridDto()
        {

        }

        public bool IsValid { get; set; }
        public SmallGridItem [] Items { get; set; }
    }

    public class SmallGridItem
    {
        public int Value { get; set; }
        public bool IsStatic { get; set; }
    }
}
