using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Treehouse.FitnessFrog.Shared.Data;
using Treehouse.FitnessFrog.Shared.Models;

namespace Treehouse.FitnessFrog.Spa.Controllers
{
    //make the resorce:

    public class EntriesController : ApiController
    {


        private EntriesRepository _entriesRepository = null;

        // Our constructor need to get "EntriesRepository" onject,
        // so we could say that: our constructor is dependency on the EntriesRepository onject.
        // witch means => DI (Dependency Injection)
        public EntriesController(EntriesRepository entriesRepository) {
            _entriesRepository = entriesRepository;
        }


        //get back a collection
        [HttpGet]
        public IHttpActionResult Get() {

            //   public IEnumerable<Entry> Get()
            //var activityBiking = new Activity() { Name="Biking"};
            //return new List<Entry>() {
            //    new Entry(2018, 1,2,activityBiking,10.0m),
            //    new Entry(2018, 1,3,activityBiking,12.2m)
            //};


            //the Ok will return respone with status code 200=ok
            return Ok(_entriesRepository.GetList());
        }

        //get back a single resorce
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var entry = _entriesRepository.Get(id);

            if (entry == null) {
                return NotFound(); // 404 error
            }

            return Ok(entry);
        }

        [HttpPost]
        public IHttpActionResult Post(Entry entry)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _entriesRepository.Add(entry);

            return Created(Url.Link("DefaultApi", new { controller="Entries", id=entry.Id }), entry); //201=created
        }

        [HttpPut]
        public void Put(int id, Entry entry)
        {
            _entriesRepository.Update(entry);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _entriesRepository.Delete(id);
        }
    }
}