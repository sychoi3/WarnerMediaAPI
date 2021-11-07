using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnerMedia.Domain.Entities;

namespace WarnerMedia.Resources
{
    public class CreditResource
    {
        public int participant_id { get; set; }
        public string name { get; set; }
        public string participant_type { get; set; }

        public int title_id { get; set; }
        public string title_name { get; set; }
        public int? release_year { get; set; }

        public bool is_key { get; set; }
        public string role_type { get; set; }
        public bool is_on_screen { get; set; }  // cast & crew

        public static CreditResource ToResource(TitleParticipant source)
        {
            if (source == null) return null;
            var dest = new CreditResource();

            var participant = source.Participant;
            dest.participant_id = participant.Id;
            dest.name = participant.Name;
            dest.participant_type = participant.ParticipantType;

            var title = source.Title;
            dest.title_id = title.TitleId;
            dest.title_name = title.TitleName;
            dest.release_year = title.ReleaseYear;

            dest.is_key = source.IsKey;
            dest.role_type = source.RoleType;
            dest.is_on_screen = source.IsOnScreen;
            return dest;
        }
        public static IList<CreditResource> ToResource(ICollection<TitleParticipant> source) => source.Select(x => ToResource(x)).ToList();
    }
}
