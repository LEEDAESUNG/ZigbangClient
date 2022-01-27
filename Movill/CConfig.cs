using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movill
{
    class CConfig
    {
        static public int apt_idx = 3276;
        static public string apt_name = "";


        //테스트서버
        //static public string tokenRoute = "https://dev-openapi.themovill.com/facility/parking/oauth2/token";
        //static public string MovillHost = "dev-openapi.themovill.com";
        //static public string carInRoute = "https://dev-openapi.themovill.com/facility/parking/v2/car-manager/LPR/in/car/info";
        //static public string carOutRoute = "https://dev-openapi.themovill.com/facility/parking/v2/car-manager/LPR/out/car/info";
        //static public string clientId = "CfI8NV4QFhG2R1USwYrD0ChVpX1velZX";
        //static public string secretKey = "AAFFohGJm0nwRF89m2cjN2Sj1pd6ZjCz";

        //실서버
        static public string tokenRoute = "https://openapi.themovill.com/facility/parking/oauth2/token";
        static public string MovillHost = "openapi.themovill.com";
        static public string carInRoute = "https://openapi.themovill.com/facility/parking/v2/car-manager/LPR/in/car/info";
        static public string carOutRoute = "https://openapi.themovill.com/facility/parking/v2/car-manager/LPR/out/car/info";
        static public string clientId = "pDx9i6Dhk5Ch21qTXW4GosNOXHU4wQdw";
        static public string secretKey = "PaGwMWJ4lixWGhYJQeAGsrKIuydfWe0h";


        static public string authToken = "";

        static public int HostRcvPort = 18498; //수신포트
    }
}
