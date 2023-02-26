using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
