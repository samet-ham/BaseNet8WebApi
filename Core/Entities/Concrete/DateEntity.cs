namespace Core.Entities.Concrete
{
    public class DateEntity
    {
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    }
}
