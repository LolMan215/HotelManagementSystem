namespace HotelManagementSystemDAL.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int? Guests { get; set; }
        public bool IsPaid { get; set; }
        public bool IsConfirmed { get; set; }
        public int? ApplicationUserId { get; set; }

        public BookingStatus BookingStatus { get; set; }
    }
}
