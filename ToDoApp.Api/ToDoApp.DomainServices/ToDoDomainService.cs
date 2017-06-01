using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;
using ToDoApp.Domain.Repositories;
using ToDoApp.DomainServices.Interfaces;

namespace ToDoApp.DomainServices
{
    internal class ToDoDomainService : IToDoDomainService
    {
        private readonly IToDoRepository repository;

        public ToDoDomainService(IToDoRepository repository)
        {
            this.repository = repository;
        }

        public ToDo Create(ToDo todo)
        {
            return this.repository.Create(todo);
        }

        public bool Delete(int id)
        {
            return this.repository.Delete(id);
        }

        public ToDo GetById(int id)
        {
            return this.repository.GetById(id);
        }

        public IEnumerable<ToDo> List(ToDoFilter filter)
        {
            return this.repository.List(filter);
        }

        public bool Update(ToDo todo)
        {
            return this.repository.Update(todo);
        }
    }
}
