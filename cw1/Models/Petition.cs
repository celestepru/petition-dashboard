using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cw1.Models
{
    public class Petition
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Member> Members { get; set; }

        public List<Petition> AllPetitions
        {
            get
            {
                return Data.Instance.Petitions;
            }
        }
    }
    
}