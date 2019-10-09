using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseLib.Services
{
    public class GatewayHostService
    {

        private IConfiguration configuration;

        public GatewayHostService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private string GetAddress()
        {
            string address =  configuration.GetValue<string>("services:apiGateway:ipAddress");
            if (string.IsNullOrEmpty(address))
            {
                return null;
            }
            return address;
        }

        private string GetPort()
        {
            string port = configuration.GetValue<string>("services:apiGateway:port");
            if (string.IsNullOrEmpty(port))
            {
                return null;
            }
            return port;
        }

        private string GetPrefix()
        {
            return configuration.GetValue<string>("services:apiGateway:prefix");
        }

        public string GetGatewayAddress()
        {
            if (GetAddress() == null)
                return null;

            if (string.IsNullOrEmpty(GetPort()))
            {
                return "http://" + GetAddress() + "/" + GetPrefix() + "";
            }

            return "http://" + GetAddress() + ":" + GetPort() + "/"+ GetPrefix() + "";
        }
    }
}
