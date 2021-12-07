

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeASAP.Data.Models
{
    public class Address
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }

    }
}
