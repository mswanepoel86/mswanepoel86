using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestingFramework.Response_Models
{
    //Nested Model we use to Deserialize the API response Json object

    public class ExampGetleResponseModel
    {
        public string activity { get; set; }
        public string type { get; set; }
        public int participants { get; set; }
        public int price { get; set; }
        public string link { get; set; }
        public string key { get; set; }
        public float accessibility { get; set; }
    }


}
