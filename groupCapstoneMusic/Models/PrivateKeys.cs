using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace groupCapstoneMusic.Models
{
    public static class PrivateKeys
    {
        //This is adam's google api code used to call our needed google api's i wrote a get ignore in txt file so it isn't pushed to github
        //if you need to use it, it is a static class, so just call googleKey in replace of the actual code
        //this way it will be hidden in the back end and wont be stolen.
        public static string googleKey = "AIzaSyBODztrEdGOpQ8GjPFCTYgWpPz_VHxXBBg";

        public static string geoURLP1 = "https://maps.googleapis.com/maps/api/geocode/json?address=";

        public static string geoURLP2 = "&key=";

        public static string directionsURLP1 = "https://maps.googleapis.com/maps/api/directions/json?";

        public static string directionsURLP2 = "&origin=";
    }
}