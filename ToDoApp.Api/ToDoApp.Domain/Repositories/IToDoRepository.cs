using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;

namespace ToDoApp.Domain.Repositories
{
    public interface IToDoRepository
    {
        Todo Create(Todo todo);

        IEnumerable<Todo> List(ToDoFilter filter);

        Todo GetById(int id);

        bool Update(Todo todo);

        bool Delete(int id);
    }
}
