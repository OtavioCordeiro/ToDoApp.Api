using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Domain.Filters
{
    public class ToDoFilter
    {
        public Nullable<int> Id { get; set; }

        public string Text { get; set; }

        public Nullable<bool> IsCompleted { get; set; }
    }
}
