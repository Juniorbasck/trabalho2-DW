﻿namespace ERP.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
        }
        
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string PassWord { get; set; }
        .
        public string? Email { get; set; }
    }
}
