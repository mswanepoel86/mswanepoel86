using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiTestingFramework.Interfaces;
using RestSharp;

namespace ApiTestingFramework
{
    public class ErrorLogger : IErrorLogger
    {
        protected IErrorLogger _errorLogger;


        public void LogError(Uri BaseUrl, IRestRequest request, IRestResponse response)
        {
            //Get the values of the parameters passed to the API
            string parameters = string.Join(", ", request.Parameters.Select(x => x.Name.ToString() + "=" + ((x.Value == null) ? "NULL" : x.Value)).ToArray());

            //Set up the information message with the URL, 
            //the status code, and the parameters.
            string info = "Request to " + BaseUrl.AbsoluteUri
                                        + request.Resource + " failed with status code "
                                        + response.StatusCode + ", parameters: "
                                        + parameters + ", and content: " + response.Content;

            //Acquire the actual exception
            Exception ex;
            if (response != null && response.ErrorException != null)
            {
                ex = response.ErrorException;
            }
            else
            {
                ex = new Exception(info);
                info = string.Empty;
            }

            //Log the exception and info message
            _errorLogger.LogError(BaseUrl,request,response);
            //Todo: log to extent report

        }

       

        //private void TimeoutCheck(IRestRequest request, IRestResponse response)
        //{
        //    if (response.StatusCode == 0)
        //    {
        //        LogError(BaseUrl, request, response);
        //    }
        //}
    }}
