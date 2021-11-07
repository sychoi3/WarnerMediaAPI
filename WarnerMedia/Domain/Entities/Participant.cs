using System;
using System.Collections.Generic;

#nullable disable

namespace WarnerMedia.Domain.Entities
{
    public partial class Participant
    {
        public Participant()
        {
            TitleParticipants = new HashSet<TitleParticipant>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ParticipantType { get; set; }

        public virtual ICollection<TitleParticipant> TitleParticipants { get; set; }
    }
}
