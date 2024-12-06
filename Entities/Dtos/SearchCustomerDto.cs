using Core.Entities;

namespace Entities.Dtos
{
    public class SearchCustomerDto : IDto
    {
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
