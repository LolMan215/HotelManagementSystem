namespace HotelManagementSystemDAL.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int RoomTypeId { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string Description { get; set; }

        public virtual RoomType RoomType { get; set; }
        public virtual List<Image> RoomImages { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
}
