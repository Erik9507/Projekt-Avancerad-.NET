using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Title { get; set; }      
    }
}
