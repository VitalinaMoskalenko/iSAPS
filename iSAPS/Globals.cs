using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using Xamarin.Forms;

namespace iSAPS
{
    public static class Globals
    {
        public static readonly EndpointAddress EndPoint = new EndpointAddress("https://wcf.isaps.pl/IsapsService.svc");
        public static string localhostAndroid = "10.0.2.2";
        public static string localhostIOS = "127.0.0.1";
        public static string localhost;

        public static string CheckOS()
        {
            if (Device.OS == TargetPlatform.Android)
            {
                localhost = localhostAndroid;
            } 
            else
            {
                localhost = localhostIOS;
            }
      
            return localhost;
        }
    }
}
