namespace HotelManagementSystemDAL.Repositories
{
    using HotelManagementSystemDAL.Entities;

    public class RoomTypeRepository : GenericRepository<RoomType>
    {
        public RoomTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
