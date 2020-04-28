using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SudockerWebApi.Dtos;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SudockerWebApi.Controllers
{
    [Route("api/[controller]")]
    public class SudokuController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IEnumerable<SmallGridItem> Create(IEnumerable<int> input)
        {
            foreach(var i in input)
            {
                yield return new SmallGridItem() {  IsStatic = i > -1, Value = i};
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public PlayGridDto Get(int id)
        {

            var grid1 = new SmallGridDto() { Items = Create(new List<int> { 5, 3, -1, 6, -1, -1, -1, 9, 8 }).ToArray() };

            var grid2 = new SmallGridDto() { Items = Create(new List<int> { -1, 7, -1, 1, 9, 5, -1, -1, -1 }).ToArray() };

            var grid3 = new SmallGridDto() { Items = Create(new List<int> { -1, -1, -1, -1, -1, -1, -1, 6, -1 }).ToArray() };

            var grid4 = new SmallGridDto() { Items = Create(new List<int> { 8, -1, -1, 4, -1, -1, 7, -1, -1 }).ToArray() };

            var grid5 = new SmallGridDto() { Items = Create(new List<int> { -1, 6, -1, 8, -1, 3, -1, 2, -1 }).ToArray() };

            var grid6 = new SmallGridDto() { Items = Create(new List<int> { -1, -1, 3, -1, -1, 1, -1, -1, 6 }).ToArray() };

            var grid7 = new SmallGridDto() { Items = Create(new List<int> { -1, 6, -1, -1, -1, -1, -1, -1, -1 }).ToArray() };

            var grid8 = new SmallGridDto() { Items = Create(new List<int> { -1, -1, -1, 4, 1, 9, -1, 8, -1 }).ToArray() };

            var grid9 = new SmallGridDto() { Items = Create(new List<int> { 2, 8, -1, -1, -1, 5, -1, 7, 9 }).ToArray() };

            return new PlayGridDto() {
                Items = new List<SmallGridDto> {
                  grid1, grid2, grid3,
                  grid4, grid5, grid6,
                  grid7, grid8, grid9
                }.ToArray()
            };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] PlayGridDto dto)
        {
        }
    }
}
