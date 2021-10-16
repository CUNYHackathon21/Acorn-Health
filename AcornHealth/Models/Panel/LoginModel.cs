using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcornHealth.Models.Panel {


    [Table("Login")]
      public class LoginModel {
        [Key]
        public int loginId { get; set; }
        [Column("loginUserName")]
        public string Username { get; set; }
        [Column("loginPassword")]
        public string Password { get; set; }
    }
}
