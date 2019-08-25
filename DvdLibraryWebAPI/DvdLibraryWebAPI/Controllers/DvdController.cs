using DvdLibraryWebAPI.Interfaces;
using DvdLibraryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DvdLibraryWebAPI.Controllers
{
    [EnableCors(origins:"*", headers: "*", methods: "*")]
    public class DvdController : ApiController
    {

        IDvdRepository _repo;
        public DvdController()
        {
            _repo = RepositoryFactory.Create();

        }

        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            return Ok(_repo.GetAll());
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            Dvd dvds = _repo.Get(id);
            if (dvds != null)
            {
                return Ok(dvds);
            }
            else
            {
                return NotFound();
            }

        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        // POST api/<controller>
        public IHttpActionResult Add(Dvd dvds)
        {
            _repo.Add(dvds);
            return Created($"dvd/{dvds.dvdId}", dvds);

        }
        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        // PUT api/<controller>/5
        public IHttpActionResult Edit(Dvd dvds)
        {
            if (dvds == null)
            {
                return NotFound();
            }
            else
            {
                _repo.Edit(dvds);
                return Ok(dvds);
            }
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            Dvd dvds = _repo.Get(id);
            if (dvds == null)
            {
                return NotFound();
            }
            else
            {
                _repo.Delete(dvds.dvdId);
                return Ok();
            }

        }
    }
}