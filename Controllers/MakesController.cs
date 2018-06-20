using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using Vega.Core.Models;
using Vega.persistance;

namespace Vega.Controllers
{
    [Route("api/[controller]")]
    public class MakesController : Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;
        public MakesController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {

            var makes = await context.Makes.Include(m => m.models).ToListAsync();
            return mapper.Map<List<Make>,List<MakeResource>>(makes);
        }
    }
}