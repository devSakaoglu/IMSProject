namespace İnternshipManagementSystem.Domain.Entities
{
    public class BaseEntity
    {
        public Guid id { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
