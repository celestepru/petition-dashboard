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
            Petitions.Add(new Petition
            {
                Id = 1,
                Title = "Title1",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam lacinia convallis tempus. Etiam non tempor sapien, eget tempus tellus. Aenean vehicula nunc in iaculis tristique. Duis eleifend eros at facilisis imperdiet. Duis porttitor ante diam, quis aliquam est varius ac. Duis id sagittis sapien. Morbi consequat viverra lacus, vel luctus lectus facilisis vitae. Praesent efficitur nisl at risus vehicula, euismod consectetur massa viverra. Curabitur a lorem maximus, condimentum sem in, ullamcorper nisl. In egestas magna ac lorem aliquet interdum. Nullam fringilla et turpis nec laoreet."
                                            ,
                Members = new List<Member>()
            });
            Petitions.Add(new Petition
            {
                Id = 2,
                Title = "Title2",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam lacinia convallis tempus. Etiam non tempor sapien, eget tempus tellus. Aenean vehicula nunc in iaculis tristique. Duis eleifend eros at facilisis imperdiet. Duis porttitor ante diam, quis aliquam est varius ac. Duis id sagittis sapien. Morbi consequat viverra lacus, vel luctus lectus facilisis vitae. Praesent efficitur nisl at risus vehicula, euismod consectetur massa viverra. Curabitur a lorem maximus, condimentum sem in, ullamcorper nisl. In egestas magna ac lorem aliquet interdum. Nullam fringilla et turpis nec laoreet."
                                            ,
                Members = new List<Member>()
            });
            Petitions.Add(new Petition
            {
                Id = 3,
                Title = "Title3",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam lacinia convallis tempus. Etiam non tempor sapien, eget tempus tellus. Aenean vehicula nunc in iaculis tristique. Duis eleifend eros at facilisis imperdiet. Duis porttitor ante diam, quis aliquam est varius ac. Duis id sagittis sapien. Morbi consequat viverra lacus, vel luctus lectus facilisis vitae. Praesent efficitur nisl at risus vehicula, euismod consectetur massa viverra. Curabitur a lorem maximus, condimentum sem in, ullamcorper nisl. In egestas magna ac lorem aliquet interdum. Nullam fringilla et turpis nec laoreet."
                                            ,
                Members = new List<Member>()
            });
        }

        public static Data Instance
        {
            get
            {
                if (instance == null) instance = new Data();
                return instance;
            }
        }
        
        public List<Petition> Petitions { get; set; }
    }
}