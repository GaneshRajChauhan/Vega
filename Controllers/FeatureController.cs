using Microsoft.AspNetCore.Mvc;
using Vega.persistance;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using vega.Controllers.Resources;
using Microsoft.EntityFrameworkCore;
using Vega.Core.Models;

namespace vega.Controllers
{ 
    [Route("api/[controller]")]
    public class FeatureController : Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;

        public FeatureController(VegaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


 
 
 
      [HttpGet("[action]")]
        public async Task<IEnumerable<KeyValuePairResource>> getFeatures()
        {
            var features = await context.features.ToListAsync();
            return mapper.Map<List<Feature>, List<KeyValuePairResource>>(features);


        }

    }
}