using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Treehouse.FitnessFrog.Shared.Data;

namespace Treehouse.FitnessFrog.Spa.Controllers
{
    public class ActivitiesController : ApiController
    {
        private ActivitiesRepository _activitiesRepository = null;

        public ActivitiesController(ActivitiesRepository activitiesRepository)
        {
            _activitiesRepository = activitiesRepository;
        }


        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_activitiesRepository.GetList());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_activitiesRepository.Get(id));
        }


    }
}