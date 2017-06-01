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

        public ToDo Create(ToDo todo)
        {
            todo.Id = connection.QueryFirst<int>("exec todo_sp_create @Text, @IsCompleted", todo);
            return todo;
        }

        public bool Delete(int id)
        {
            int affectedRowns = connection.Execute("Exec todo_sp_delete @Id", new { Id = id });

            return affectedRowns > 0;
        }

        public ToDo GetById(int id)
        {
            ToDo result = connection.QueryFirstOrDefault<ToDo>("Exec todo_sp_get @Id", new { Id = id });

            return result;
        }

        public IEnumerable<ToDo> List(ToDoFilter filter)
        {
            IEnumerable<ToDo> result = connection.Query<ToDo>("exec todo_sp_list @Id, @Text, @IsCompleted", filter);

            return result;
        }

        public bool Update(ToDo todo)
        {
            int affectedRowns = connection.Execute("exec todo_sp_list @Id, @Text, @IsCompleted", todo);

            return affectedRowns > 0;
        }
    }
}
