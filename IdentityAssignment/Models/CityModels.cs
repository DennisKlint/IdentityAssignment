using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityAssignment.Models
{
    public class CityModels
    {
        public int ID { get; set; }
        public int CountryModelsID { get; set; }
        public string CityName { get; set; }

        public CountryModels Country { get; set; }

        public ICollection<PersonModels> People { get; set; }
    }
}