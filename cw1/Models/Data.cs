using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;

namespace cw1.Models
{
    public class Data
    {
        static Data instance = null;
        Data()
        {
            Petitions = new List<Petition>();
            Petitions.Add(new Petition { Title = "Title1", Description = "Lorem ipsum dolor sit amet", Members = new List<Member>() });
            Petitions.Add(new Petition { Title = "Title2", Description = "Lorem ipsum dolor sit amet", Members = new List<Member>() });
            Petitions.Add(new Petition { Title = "Title3", Description = "Lorem ipsum dolor sit amet", Members = new List<Member>() });

            Members = new List<Member>();
            Members.Add(new Member { Username = "jsm", Name = "John", Surname = "Smith" });
            Members.Add(new Member { Username = "edw", Name = "Elizabeth", Surname = "Edwards" });
            Members.Add(new Member { Username = "gra", Name = "George", Surname = "Grant" });

            Petitions[0].Members.Add(Members[0]);
            Petitions[0].Members.Add(Members[1]);
            Petitions[1].Members.Add(Members[1]);
            Petitions[1].Members.Add(Members[2]);
            Petitions[2].Members.Add(Members[2]);
            Petitions[2].Members.Add(Members[1]);
            Petitions[2].Members.Add(Members[0]);
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

        public void SaveMembers()
        {
            string json = JsonConvert.SerializeObject(Members.ToArray());
            //write string to file
            File.WriteAllText(@"C:\Users\celes\source\repos\cw1\cw1\Content\testd.json", json);
        }
    }
}