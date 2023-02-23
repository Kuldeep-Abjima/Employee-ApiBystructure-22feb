using Employee.microservice.model.Enum;

namespace Employee.microservice.model
{
    public class EmployeeModel
    {
        //public long EmpId { get; set; }

        public string? EmployeeName { get; set; }

        public string? Email { get; set; }

        public EmployeeCategory? Category { get; set; }

        public EmployeeGender? Gender { get; set; }
    }
}