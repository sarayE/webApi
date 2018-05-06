using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Treehouse.FitnessFrog.Shared.Models;

namespace Treehouse.FitnessFrog.Spa.Controllers
{
    public class IntensitiesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            var results = Enum.GetValues(typeof(Entry.IntensityLevel)).
                Cast<Entry.IntensityLevel>().
                Select(il => new { id = (int)il, name = il.ToString() })
                .ToString();

            return Ok(results);
        }
    }
}