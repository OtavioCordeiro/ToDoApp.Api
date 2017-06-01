using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Data.Repositories;
using ToDoApp.Domain.Repositories;

namespace ToDoApp.Data.IoC
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
