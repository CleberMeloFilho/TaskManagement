﻿using System.Collections.Generic;

namespace TaskManagement.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}