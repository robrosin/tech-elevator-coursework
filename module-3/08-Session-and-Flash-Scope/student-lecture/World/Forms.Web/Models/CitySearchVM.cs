using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.Models
{
    public class CitySearchVM
    {
        // TODO 02: Add a Display Data Annotation to set a label for these fields
        [Display(Name = "Country Code", Prompt = "3-character ISO code")]
        public string CountryCode { get; set; }

        [Display(Prompt = "e.g., Ohio")]
        public string District { get; set; }
        public IList<City> Cities { get; set; }

        // TODO 01a: Add a place to store a list of countries to the view-model
        public SelectList CountryList { get; set; }
    }
}
