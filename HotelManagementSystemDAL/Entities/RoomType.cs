namespace HotelManagementSystemDAL.Entities
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaximumGuests { get; set; }
        public string Description { get; set; }
        public string RoomEquipment { get; set; }
        public decimal BasePrice { get; set; }
        public int Discount { get; set; }

        public List<Image> RoomImages { get; set; }
    }
}
