namespace HotelManagementSystemDAL.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<int>
    {
        public override int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Booking> Booking { get; set; } = [];
    }
}
