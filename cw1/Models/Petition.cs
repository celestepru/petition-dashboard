using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cw1.Models
{
    [Table("members")]
    public class Petition
    {
        [Key]
        public int Id { get; set; }
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