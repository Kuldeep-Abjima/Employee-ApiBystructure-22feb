namespace Employee.microservice.domain
{
    public class BaseDto
    {
        public BaseDto()
        {
            Identifier = Guid.NewGuid();
            Createdat = DateTime.UtcNow;
            Updatedat= DateTime.UtcNow;
        }
        public Guid Identifier { get; set; }
        public DateTime Createdat { get; set; }

        public DateTime Updatedat { get; set; }

    }
}