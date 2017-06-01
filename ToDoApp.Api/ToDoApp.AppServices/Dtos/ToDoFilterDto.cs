using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.AppServices.Dtos
{
    public class ToDoFilterDto
    {
        public Nullable<int> Id { get; set; }

        public string Text { get; set; }

        public Nullable<bool> IsCompleted { get; set; }
    }
}
