using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace JwtAuthService.Models
{
    public class User
    {
        public String Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }        
    } 
}
