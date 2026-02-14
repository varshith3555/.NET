using System;
using System.Collections.Generic;
using System.Linq;

namespace GymMembershipManagement
{
    public class GymManager
    {
        private List<Member> members = new List<Member>();
        private List<FitnessClass> classes = new List<FitnessClass>();
        private int memberId = 1001;

        public void AddMember(string name, string membershipType, int months)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Member name cannot be empty.");

            members.Add(new Member
            {
                MemberId = memberId++,
                Name = name,
                MembershipType = membershipType,
                JoinDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddMonths(months)
            });
        }

        public void AddClass(string className, string instructor, DateTime schedule, int maxParticipants)
        {
            if (string.IsNullOrWhiteSpace(className))
                throw new ArgumentException("Class name cannot be empty.");

            classes.Add(new FitnessClass
            {
                ClassName = className,
                Instructor = instructor,
                Schedule = schedule,
                MaxParticipants = maxParticipants
            });
        }

        public bool RegisterForClass(int memberId, string className)
        {
            var member = members.FirstOrDefault(m => m.MemberId == memberId);
            if (member == null)
                throw new Exception("Member not found.");

            var fitnessClass = classes.FirstOrDefault(c => c.ClassName == className);
            if (fitnessClass == null)
                throw new Exception("Class not found.");

            if (fitnessClass.RegisteredMembers.Count >= fitnessClass.MaxParticipants)
                return false;

            fitnessClass.RegisteredMembers.Add(member.Name);
            return true;
        }

        public Dictionary<string, List<Member>> GroupMembersByMembershipType()
        {
            var grouped = new Dictionary<string, List<Member>>();
            foreach (var member in members)
            {
                if (!grouped.ContainsKey(member.MembershipType))
                    grouped[member.MembershipType] = new List<Member>();
                grouped[member.MembershipType].Add(member);
            }
            return grouped;
        }

        public List<FitnessClass> GetUpcomingClasses()
        {
            DateTime now = DateTime.Now;
            DateTime nextWeek = now.AddDays(7);
            return classes.Where(c => c.Schedule >= now && c.Schedule <= nextWeek).ToList();
        }
    }
}
