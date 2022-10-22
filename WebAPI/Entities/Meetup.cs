using System.ComponentModel.DataAnnotations;

namespace MeetupAPI.Entities
{
    public class Meetup : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Plan { get; set; }

        public string Organizer { get; set; }

        public string Speaker { get; set; }

        public DateTime Time { get; set; }

        public string Location { get; set; }
    }
}
