using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.microservice.domain
{
    public class EmployeeDto : BaseDto
    {

        [Key]
        public long EmpId { get; set; }

        public string Name { get; set; }

        public string? Email { get; set; }

        public int? Category { get; set; }

        public int? Gender { get; set; }
    }
}
