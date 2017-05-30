using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Data.Repositories;
using ToDoApp.Domain.Repositories;

namespace TodoApp.Data.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>();

            dictionary.Add(typeof(IToDoRepository), typeof(ToDoRepository));

            return dictionary;
        }
    }
}
