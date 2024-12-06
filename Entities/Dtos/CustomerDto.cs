using Core.Entities;

namespace Entities.Dtos
{
    public class CustomerDto : IDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
