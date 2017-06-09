using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.AppServices.Dtos;
using ToDoApp.AppServices.Interfaces;
using ToDoApp.Validators;
using ToDoApp.Results;
using ToDoApp.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        private readonly IToDoAppService appService;
        private readonly ToDoValidator Validator;

        public ToDoController(IToDoAppService appService, ToDoValidator validator)
        {
            this.appService = appService;
            this.Validator = validator;
        }

        // GET: api/todo
        [HttpGet]
        public GenericResult<IEnumerable<ToDoDto>> Get([FromQuery]ToDoFilterDto filter)
        {
            var result = new GenericResult<IEnumerable<ToDoDto>>();

            try
            {
                result.Result = this.appService.List(filter);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }

        // GET api/todo/5
        [HttpGet("{id}")]
        public GenericResult<ToDoDto> Get(int id)
        {
            var result = new GenericResult<ToDoDto>();

            try
            {
                result.Result = this.appService.GetById(id);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }

        // POST api/todo
        [HttpPost]
        public GenericResult<ToDoDto> Post([FromBody]ToDoDto model)
        {
            var result = new GenericResult<ToDoDto>();

            var validationResult = Validator.Validate(model);
            if (validationResult.IsValid)
            {
                try
                {
                    result.Result = this.appService.Create(model);
                    result.Success = true;
                }
                catch (Exception ex)
                {

                    result.Errors = new string[] { ex.Message };
                }
            }
            else
            {
                result.Errors = validationResult.GetErrors();
            }


            return result;
        }

        // PUT api/todo/5
        [HttpPut("{id}")]
        public GenericResult Put(int id, [FromBody]ToDoDto model)
        {
            model.Id = id;

            var result = new GenericResult();

            var validationResult = Validator.Validate(model);
            if (validationResult.IsValid)
            {
                try
                {
                    result.Success = this.appService.Update(model);
                }
                catch (Exception ex)
                {
                    result.Errors = new string[] { ex.Message };
                }
            }
            else
            {
                result.Errors = validationResult.GetErrors();
            }

            return result;
        }

        // DELETE api/todo/5
        [HttpDelete("{id}")]
        public GenericResult Delete(int id)
        {
            var result = new GenericResult();

            try
            {
                result.Success = this.appService.Delete(id);
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }
    }
}
