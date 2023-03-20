namespace Backend.Models
{
    public class t_Travel
    {
        public int TravelId { get; set; }
        public int UserId { get; set; }
        public int FromCityId { get; set; }
        public int ToCityId { get; set; }
        public int NoOfSeats { get; set; }
        public DateTime TravelDate { get; set; }
    }
}