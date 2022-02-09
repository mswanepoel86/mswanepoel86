using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestingFramework.Request_Models
{
    //The Model used to Serialize to our Json request body object
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserID { get; set; }
        public string DateOfBirth { get; set; }
    }

}
