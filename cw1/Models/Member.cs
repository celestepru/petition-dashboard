using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cw1.Models
{
    //Define member table for database
    [Table("Members")]

    /* Member model 
     Each member has a username, name, surname, role and password.*/
    public class Member
    {
        [Key]
        public string Username { get; set; }    //define username as primary key

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }    //To define admin members and regular members
        public string Password { get; set; }
    }
}