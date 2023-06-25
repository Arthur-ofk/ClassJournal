namespace Entities.Models
{
    public class Mark
    {
        public Guid Id { get; set; }
        public Guid SubjectId { get; set; }
        public int MarkValue { get; set; }
        public DateTime CreatedDate { get; set; }

        public Guid StudentId { get; set; }




    }
}
