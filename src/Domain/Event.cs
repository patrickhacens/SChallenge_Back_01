namespace SChallenge.Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumOfParticipants { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }

        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }
    }
}
