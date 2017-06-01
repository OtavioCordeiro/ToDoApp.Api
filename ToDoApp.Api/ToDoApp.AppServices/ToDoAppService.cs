using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.AppServices.Dtos;
using ToDoApp.AppServices.Extencions;
using ToDoApp.AppServices.Interfaces;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;
using ToDoApp.DomainServices.Interfaces;

namespace ToDoApp.AppServices
{
    internal class ToDoAppService : IToDoAppService
    {
        private readonly IToDoDomainService service;

        public ToDoAppService(IToDoDomainService service)
        {
            this.service = service;
        }

        public ToDoDto Create(ToDoDto todo)
        {
            var result = this.service.Create(todo.MapTo<ToDo>());
            return result.MapTo<ToDoDto>();
        }

        public bool Delete(int id)
        {
            return this.service.Delete(id);
        }

        public ToDoDto GetById(int id)
        {
            return this.service.GetById(id).MapTo<ToDoDto>();
        }

        public IEnumerable<ToDoDto> List(ToDoFilterDto filter)
        {
            var result = this.service.List(filter.MapTo<ToDoFilter>());

            return result.EnumerableTo<ToDoDto>();
        }

        public bool Update(ToDoDto todo)
        {
            return this.service.Update(todo.MapTo<ToDo>());
        }
    }
}
