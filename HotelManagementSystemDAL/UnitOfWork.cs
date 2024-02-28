namespace HotelManagementSystemDAL
{
    using HotelManagementSystemDAL.Entities;
    using HotelManagementSystemDAL.Interfaces;
    using HotelManagementSystemDAL.Repositories;

    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<ApplicationUser> _applicationUserRepository;
        private IGenericRepository<Booking> _bookingRepository;
        private IGenericRepository<Image> _imageRepository;
        private IGenericRepository<Room> _roomRepository;
        private IGenericRepository<RoomType> _roomTypeRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<ApplicationUser> ApplicationUserRepository
        {
            get
            {
                if (_applicationUserRepository == null)
                {
                    _applicationUserRepository = new ApplicationUserRepository(_context);
                }
                return _applicationUserRepository;
            }
        }

        public IGenericRepository<Booking> BookingRepository
        {
            get
            {
                if (_bookingRepository == null)
                {
                    _bookingRepository = new BookingRepository(_context);
                }
                return _bookingRepository;
            }
        }

        public IGenericRepository<Image> ImageRepository
        {
            get
            {
                if (_imageRepository == null)
                {
                    _imageRepository = new ImageRepository(_context);
                }
                return _imageRepository;
            }
        }

        public IGenericRepository<Room> RoomRepository
        {
            get
            {
                if (_roomRepository == null)
                {
                    _roomRepository = new RoomRepository(_context);
                }
                return _roomRepository;
            }
        }

        public IGenericRepository<RoomType> RoomTypeRepository
        {
            get
            {
                if (_roomTypeRepository == null)
                {
                    _roomTypeRepository = new RoomTypeRepository(_context);
                }
                return _roomTypeRepository;
            }
        }
    }
}
