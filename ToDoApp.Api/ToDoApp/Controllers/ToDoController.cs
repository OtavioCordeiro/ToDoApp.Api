using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.AppServices.Dtos;
using ToDoApp.AppServices.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        private readonly IToDoAppService appService;

        public ToDoController(IToDoAppService appService)
        {
            this.appService = appService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<ToDoDto> Get([FromQuery]ToDoFilterDto filter)
        {
            return this.appService.List(filter);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ToDoDto Get(int id)
        {
            return this.appService.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public ToDoDto Post([FromBody]ToDoDto model)
        {
            return this.appService.Create(model);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody]ToDoDto model)
        {
            model.Id = id;
            return this.appService.Update(model);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return this.appService.Delete(id);
        }
    }
}
