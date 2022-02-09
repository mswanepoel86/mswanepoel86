using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace ApiTestingFramework.Interfaces
{
    public interface IErrorLogger
    {
        void LogError(Uri BaseUrl, IRestRequest request, IRestResponse response);
       
    }
}
