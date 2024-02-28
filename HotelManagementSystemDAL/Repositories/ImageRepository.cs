namespace HotelManagementSystemDAL.Repositories
{
    using HotelManagementSystemDAL.Entities;

    public class ImageRepository : GenericRepository<Image>
    {
        public ImageRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
