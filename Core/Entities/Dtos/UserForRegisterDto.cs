namespace Core.Entities.Dtos
{
    public class UserForRegisterDto : IDto
    {
        public string Mail { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
