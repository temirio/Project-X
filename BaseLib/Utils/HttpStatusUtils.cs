using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BaseLib.Utils
{
    public class HttpStatusUtils
    {
        static readonly HttpStatusCode[] successStatus = new HttpStatusCode[]
        {
            HttpStatusCode.OK,
            HttpStatusCode.Created,
            HttpStatusCode.Accepted,
            HttpStatusCode.NonAuthoritativeInformation,
            HttpStatusCode.NoContent,
            HttpStatusCode.ResetContent,
            HttpStatusCode.PartialContent
        };

        public static bool Is2xxSuccessful(HttpStatusCode httpStatusCode)
        {
            for (int i = 0; i < successStatus.Length; i++)
            {
                if (successStatus[i] == httpStatusCode)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
