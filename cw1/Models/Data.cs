using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cw1.Models
{
    public class Data
    {
        static Data instance = null;
        Data()
        {
            Members = new List<Member>();
        }

        public static Data Instance
        {
            get
            {
                if (instance == null) instance = new Data();
                return instance;
            }
        }

        public List<Member> Members { get; set; }
        public List<Petition> Petitions { get; set; }
    }
}