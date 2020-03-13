using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.Models
{
    public class City
    {
        public int CityId { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(64)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Country Code must be exactly 3  characters.")]
        [Display(Name = "Country Code", Prompt = "e.g., \"USA\"")]
        public string CountryCode { get; set; }
        
        public string CountryName { get; set; }

        [Required]
        public string District { get; set; }

        [Range(1, 99999999)]
        public int Population { get; set; }

        public City() { }

        public City(int cityId, String name, string countryCode, string countryName, string district, int population)
        {
            CityId = cityId;
            Name = name;
            CountryCode = countryCode;
            CountryName = countryName;
            District = district;
            Population = population;
        }
    }
}
