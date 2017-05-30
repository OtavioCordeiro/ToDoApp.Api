using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Filters;
using ToDoApp.Domain.Repositories;
using Dapper;

namespace TodoApp.Data.Repositories
{
    public class ToDoRepository : RepositoryBase, IToDoRepository
    {
        public ToDoRepository(IConfigurationRoot configuration) : base(configuration) { }

        public Todo Create(Todo todo)
        {
            todo.Id = connection.QueryFirst<int>("exec todo_sp_create @Text, @IsCompleted", todo);
            return todo;
        }

        public bool Delete(int id)
        {
            int affectedRowns = connection.Execute("Exec todo_sp_delete @Id", new { Id = id });

            return affectedRowns > 0;
        }

        public Todo GetById(int id)
        {
            Todo result = connection.QueryFirstOrDefault<Todo>("Exec todo_sp_get @Id", new { Id = id });

            return result;
        }

        public IEnumerable<Todo> List(ToDoFilter filter)
        {
            IEnumerable<Todo> result = connection.Query<Todo>("exec todo_sp_list @Id, @Text, @IsCompleted", filter);

            return result;
        }

        public bool Update(Todo todo)
        {
            int affectedRowns = connection.Execute("exec todo_sp_list @Id, @Text, @IsCompleted", todo);

            return affectedRowns > 0;
        }
    }
}
