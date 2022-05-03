namespace SChallenge.Models
{
    public class EditEventRequestDTO
    {
        public string Name { get; set; }
        public int NumOfParticipants { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Duration { get; set; }
    }
}
