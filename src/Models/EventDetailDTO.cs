namespace SChallenge.Models
{
    public class EventDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumOfParticipants { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }

        public string CreatorName { get; set; }
    }
}
