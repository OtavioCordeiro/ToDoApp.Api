using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.DomainServices.Interfaces;

namespace ToDoApp.DomainServices.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>();

            dictionary.Add(typeof(IToDoDomainService), typeof(ToDoDomainService));

            return dictionary;
        }
    }
}
