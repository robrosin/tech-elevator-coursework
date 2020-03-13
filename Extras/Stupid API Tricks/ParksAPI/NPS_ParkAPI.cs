using System;
using System.Collections.Generic;
using System.Text;

/*** Full API Model, from https://www.nps.gov/subjects/developer/api-documentation.htm#/parks/getPark
 * 	Model
[Park{
    total	integer ($int32)
    example: 1
    limit	integer ($int32)
    example: 50
    start	integer ($int32)
    example: 1
    data	
    [{
        states	string
        State(s) the park is located in (comma-delimited list)

        weatherInfo	string
        General description of the weather in the park over the course of a year

        directionsInfo	string
        General overview of how to get to the park

        *** NOT DEFAULT:
        addresses	[{
            postalCode	string
            city	string
            stateCode	string
            line1	string
            type	string
            Enum:
            [ Physical, Mailing ]
            line3	string
            line2	string
        }]
        description:Park addresses (physical and mailing)
        
        *** NOT DEFAULT:
        entranceFees	[{
            cost	number ($float)
            description	string
            title	string
        }]
        description:Fee for entering the park
        
        name	string
        Short park name (no designation)

        *** NOT DEFAULT:
        operatingHours	[{
            name	string
            description	string
            standardHours	{
                sunday	string
                monday	string
                tuesday	string
                wednesday	string
                thursday	string
                friday	string
                saturday	string
            }
            exceptions	[{
                name	string
                startDate	string ($date-time)
                endDate	string ($date-time)
                exceptionHours	{...}
            }]
        }]
        description:Hours and seasons when the park is open or closed

        url	string
        Park Website

        *** NOT DEFAULT:
        contacts	{
            description:	
            Information about contacting the park

            phoneNumbers	[...]
            emailAddresses	[...]
        }

        *** NOT DEFAULT:
        entrancePasses	[{...}]
        description:Passes available to provide entry into the park

        parkCode	string
        A variable width character code used to identify a specific park

        designation	string
        Type of designation (eg, national park, national monument, national recreation area, etc)

        *** NOT DEFAULT:
        images	[{
            credit	string
            altText	string
            title	string
            id	integer ($int32)
            caption	string
            url	string
        }]
        description:Park images

        fullName	string
        Full park name (with designation)

        latLong	string
        Park GPS cordinates

        id	string
        Park identification string

        directionsUrl	string
        Link to page, if available, that provides additional detail on getting to the park

        description	string
        Introductory paragraph from the park homepage

    }]
}]
***/



namespace ParksAPI
{
    #region Parks without additional fields
    /*** With NO extra fields
    public class NPS_ParkAPI
    {
        public string total { get; set; }
        public NPS_Park[] data { get; set; }
        public string limit { get; set; }
        public string start { get; set; }
    }

    public class NPS_Park
    {
        public string states { get; set; }
        public string latLong { get; set; }
        public string description { get; set; }
        public string designation { get; set; }
        public string parkCode { get; set; }
        public string id { get; set; }
        public string directionsInfo { get; set; }
        public string directionsUrl { get; set; }
        public string fullName { get; set; }
        public string url { get; set; }
        public string weatherInfo { get; set; }
        public string name { get; set; }
    }
    ***/
    #endregion

    #region Parks with additional fields: entranceFees,images,operatingHours
    // https://developer.nps.gov/api/v1/parks?fields=entranceFees,images,operatingHours&api_key=YourKey

    public class NPS_ParkAPI
    {
        public string total { get; set; }
        public NPS_Park[] data { get; set; }
        public string limit { get; set; }
        public string start { get; set; }
    }

    public class NPS_Park
    {
        public string states { get; set; }
        public Entrancefee[] entranceFees { get; set; }
        public string directionsInfo { get; set; }
        public string directionsUrl { get; set; }
        public string url { get; set; }
        public string weatherInfo { get; set; }
        public string name { get; set; }
        public Operatinghour[] operatingHours { get; set; }
        public string latLong { get; set; }
        public string description { get; set; }
        public Image[] images { get; set; }
        public string designation { get; set; }
        public string parkCode { get; set; }
        public string id { get; set; }
        public string fullName { get; set; }
    }

    public class Entrancefee
    {
        public string cost { get; set; }
        public string description { get; set; }
        public string title { get; set; }
    }

    public class Operatinghour
    {
        public Exception[] exceptions { get; set; }
        public string description { get; set; }
        public Standardhours standardHours { get; set; }
        public string name { get; set; }
    }

    public class Standardhours
    {
        public string wednesday { get; set; }
        public string monday { get; set; }
        public string thursday { get; set; }
        public string sunday { get; set; }
        public string tuesday { get; set; }
        public string friday { get; set; }
        public string saturday { get; set; }
    }

    public class Exception
    {
        public Exceptionhours exceptionHours { get; set; }
        public string startDate { get; set; }
        public string name { get; set; }
        public string endDate { get; set; }
    }

    public class Exceptionhours
    {
        public string wednesday { get; set; }
        public string monday { get; set; }
        public string thursday { get; set; }
        public string sunday { get; set; }
        public string tuesday { get; set; }
        public string friday { get; set; }
        public string saturday { get; set; }
    }

    public class Image
    {
        public string credit { get; set; }
        public string altText { get; set; }
        public string title { get; set; }
        public string id { get; set; }
        public string caption { get; set; }
        public string url { get; set; }
    }
    #endregion

}
