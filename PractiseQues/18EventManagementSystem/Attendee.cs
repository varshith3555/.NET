namespace _18EventManagementSystem
{
    public class Attendee
    {
        public int AttendeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<int> RegisteredEvents { get; set; }

        public Attendee()
        {
            RegisteredEvents = new List<int>();
        }
    }
}
