﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Domain.Entities
{
   public  class ToDo
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsCompleted { get; set; }
    }
}
