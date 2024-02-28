namespace HotelManagementSystemDAL.Repositories
{
    using HotelManagementSystemDAL.Entities;

    public class ApplicationUserRepository : GenericRepository<ApplicationUser>
    {
        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
