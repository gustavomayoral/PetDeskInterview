using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetDeskInterview.Models
{

    //{
    // "appointmentId": 290318,
    // "appointmentType": "Other",
    // "createDateTime": "2018-11-28T22:57:33",
    // "requestedDateTimeOffset": "2018-12-01T08:00:00-08:00",
    // "user": {
    //     "userId": 115066,
    //     "firstName": "Tracey",
    //     "lastName": "Polzin"
    // },

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
    // "animal": {
    //     "animalId": 137900,
    //     "firstName": "Jackson",
    //     "species": "Dog",
    //     "breed": "German Shepherd"
    // }
    public class animal
    {
        public int animalId { get; set; }
        public string firstName { get; set; }
        public string species { get; set; }
        public string breed { get; set; }

    }
}
