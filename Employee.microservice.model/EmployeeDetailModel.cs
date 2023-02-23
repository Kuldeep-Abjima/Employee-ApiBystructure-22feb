using Employee.microservice.model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.microservice.model
{
    public class EmployeeDetailModel
    {
        public long EmpId { get; set; }

        public string? EmployeeName { get; set; }

        public string? Email { get; set; }

        public EmployeeCategory? Category { get; set; }

        public EmployeeGender? Gender { get; set; }
    }
}
