using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.AppServices.Interfaces;

namespace ToDoApp.AppServices.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>();

            dictionary.Add(typeof(IToDoAppService), typeof(ToDoAppService));

            return dictionary;
        }
    }
}
