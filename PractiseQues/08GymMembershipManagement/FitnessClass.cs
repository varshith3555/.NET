using System;
using System.Collections.Generic;

namespace GymMembershipManagement
{
    public class FitnessClass
    {
        public string ClassName { get; set; }
        public string Instructor { get; set; }
        public DateTime Schedule { get; set; }
        public int MaxParticipants { get; set; }
        public List<string> RegisteredMembers { get; set; }

        public FitnessClass()
        {
            RegisteredMembers = new List<string>();
        }
    }
}
