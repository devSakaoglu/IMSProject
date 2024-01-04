namespace İnternshipManagementSystem.Domain.Entities
{
    public class FileData : BaseEntity
    {
        public string InternshipId { get; set; }
      
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string ContentID { get; set; }


    }
}

