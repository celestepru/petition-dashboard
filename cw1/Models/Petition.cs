using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cw1.Models
{
    //Define petition table for data source
    [Table("Petitions")]
    /*
     Petition model
     Each petition has an Id, a title, a description, and a list of members that have signed it.*/
    public class Petition
    {
        [Key]
        public int Id { get; set; } //define id as primary key

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<Member> Members { get; set; }    //list of members (signatures)
        
    }
    
}