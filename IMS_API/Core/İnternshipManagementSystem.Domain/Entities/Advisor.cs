namespace İnternshipManagementSystem.Domain.Entities
{
    public class Advisor :BaseEntity
    {
        public string? AdviserID { get; set; }
        public string? AdviserName { get; set; }
        public string? AdviserSurname { get; set; }
        public string? TC_ID { get; set; }
        public string? DepartmentName { get; set; }
        public string? AdviserGSMNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public ICollection<Student>? Students { get; set; }

    }
}

