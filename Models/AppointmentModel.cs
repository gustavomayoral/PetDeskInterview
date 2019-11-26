using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetDeskInterview.Models
{

    public class ChangeDto
    {
        public int changeId { get; set; }
        public string proposedDate { get; set; }
        public string proposedTime { get; set; }

    }
    public class Appointment
    {
        public int appointmentId { get; set; }
        public string appointmentType { get; set; }
        public DateTime createdDateTime { get; set; }
        public DateTime requestedDateTimeOffset { get; set; }
        public user user { get; set; }
        public animal animal { get; set; }
    }

    public class user
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

    }

    public class animal
    {
        public int animalId { get; set; }
        public string firstName { get; set; }
        public string species { get; set; }
        public string breed { get; set; }

    }
}
