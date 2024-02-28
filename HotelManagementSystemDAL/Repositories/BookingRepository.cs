namespace HotelManagementSystemDAL.Repositories
{
    using HotelManagementSystemDAL.Entities;

    public class BookingRepository : GenericRepository<Booking>
    {
        public BookingRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
