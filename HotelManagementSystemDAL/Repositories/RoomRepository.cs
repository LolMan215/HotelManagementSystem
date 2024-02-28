namespace HotelManagementSystemDAL.Repositories
{
    using HotelManagementSystemDAL.Entities;

    public class RoomRepository : GenericRepository<Room>
    {

        public RoomRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
