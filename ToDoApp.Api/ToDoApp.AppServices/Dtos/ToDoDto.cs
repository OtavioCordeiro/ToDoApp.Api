using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.AppServices.Dtos
{
    public class ToDoDto
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsCompleted { get; set; }
    }
}
