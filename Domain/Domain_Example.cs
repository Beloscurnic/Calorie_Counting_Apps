using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Domain_Example
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public string Email { get; set; }

       
    }
}
